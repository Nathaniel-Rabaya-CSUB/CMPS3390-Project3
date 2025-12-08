using UnityEngine;
using TMPro;

public class PlayerScoreUI : MonoBehaviour
{
    void Start()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        text.text = "Score: 0";
    }

    void Update()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        text.text = "Score: " + compareNPCdata.score;
    }
}
