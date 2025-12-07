using System.Collections;
using UnityEngine;
using WeatherApp.API;

public class WeatherManager : MonoBehaviour
{
    public IpService ipService;
    public GeoService geoService;
    public WeatherService weatherService;
    public ImageController imageController;

    public bool debugLogs = true;

    // Refresh rate
    public float refreshInterval = 600f;

    private void Start()
    {
        StartCoroutine(MainWeatherLoop());
    }

    private IEnumerator MainWeatherLoop()
    {
        while (true)
        {
            // Fetch IP → Geo → Weather and update the UI
            yield return UpdateWeatherData();

            if (refreshInterval <= 0)
                yield break;

            yield return new WaitForSeconds(refreshInterval);
        }
    }

    private IEnumerator UpdateWeatherData()
    {
        string error = null;
        string publicIp = null;

        // Get Public IP
        yield return ipService.GetPublicIp(
            ipAddress => publicIp = ipAddress,
            errorMessage => error = "IP error: " + errorMessage
        );
        if (error != null) { Debug.LogError(error); yield break; }

        // Convert IP to Geo Coordinates
        float latitude = 0f;
        float longitude = 0f;

        yield return geoService.GetGeoForIp(
            publicIp,
            (lat, lon) => { latitude = lat; longitude = lon; },
            errorMessage => error = "Geo error: " + errorMessage
        );
        if (error != null) { Debug.LogError(error); yield break; }

        // Gets Weather for Coordinates
        OpenMeteoResponse weatherData = null;

        yield return weatherService.GetHourlyWeather(
            latitude,
            longitude,
            data => weatherData = data,
            errorMessage => error = "Weather error: " + errorMessage
        );
        if (error != null) { Debug.LogError(error); yield break; }

        var hourly = weatherData.hourly;

        int closestTimeIndex = WeatherService.FindNearestIndex(hourly.time);
        if (closestTimeIndex < 0) yield break;

        float totalPrecipitation =
            hourly.rain[closestTimeIndex] +
            hourly.showers[closestTimeIndex];

        bool isDaytime = hourly.is_day[closestTimeIndex] == 1;
        int weatherCode = hourly.weathercode[closestTimeIndex];

        string weatherCondition;

        if (totalPrecipitation > 0.1f)
            weatherCondition = "rain";
        else if (weatherCode <= 3)
            weatherCondition = "cloudy";
        else if (!isDaytime)
            weatherCondition = "night";
        else
            weatherCondition = "day";

        if (debugLogs)
            Debug.Log(
                $"Weather: code={weatherCode}, precipitation={totalPrecipitation}, " +
                $"isDay={isDaytime} -> condition={weatherCondition}"
            );

        // Update the UI image based on condition
        imageController.SetCondition(weatherCondition);
    }
}

