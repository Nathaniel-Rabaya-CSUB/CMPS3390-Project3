using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Sprite daySprite;
    public Sprite nightSprite;
    public Sprite rainSprite;
    public Sprite cloudySprite;

    public Image targetImage;

    private void Reset()
    {
        targetImage = GetComponent<Image>();
    }

    // Chooses the correct sprite based on a weather condition string
    public void SetCondition(string weatherCondition)
    {
        if (targetImage == null) return;


        Sprite selectedSprite = weatherCondition switch
        {
            "day" => daySprite,
            "night" => nightSprite,
            "rain" => rainSprite,
            "cloudy" => cloudySprite,
            _ => daySprite
        };

        // Actually apply the new sprite to the UI
        targetImage.sprite = selectedSprite;
    }
}

