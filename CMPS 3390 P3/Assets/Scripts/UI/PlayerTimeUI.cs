using UnityEngine;
using TMPro;

public class PlayerTimeUI : MonoBehaviour
{
    void Start()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        text.text = "Time: 0s";
    }

    void Update()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        text.text = "Time: " + compareNPCdata.seconds + "s";
    }
}
