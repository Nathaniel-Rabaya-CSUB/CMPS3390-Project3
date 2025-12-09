using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using UnityEngine.SceneManagement;

public class SendPlayerData : MonoBehaviour
{
    public GameObject inputField;
    public GameObject warningLabel;
    public TextMeshProUGUI resultField;
    public new string name;
    public string resultText;

    public void Start()
    {
        warningLabel.SetActive(false); // Hide Warning
    }

    public void ReadInput()
    {
        name = inputField.GetComponent<TMP_InputField>().text;
    }

    public bool ValidateInput()
    {
        // var to check if validated
        bool returnResult = true;

        // input is empty
        if(string.IsNullOrWhiteSpace(name))
        {
            resultText = "You did not enter a name";
            returnResult = false;
        }

        // input has non-letter characters
        else if(!name.All(char.IsLetter))
        {
            resultText = "Your name contains non-letter characters";
            returnResult = false;
        }

        // input too short
        else if(name.Length < 3)
        {
            resultText = "The name you entered is too short.";
            returnResult = false;
        }

        // input too long
        else if(name.Length > 15)
        {
            resultText = "The name you entered is too long.";
            returnResult = false;
        }

        resultField.text = resultText;
        warningLabel.SetActive(true); // Display Warning
        return returnResult;
    }

    public void createJson()
    {
        ReadInput();

        // user input wasn't validated
        if (ValidateInput() == false) { return; }

        else
        {
            // create PlayerData instance
            PlayerData data = new PlayerData();

            // set data
            data.score = compareNPCdata.score;
            data.seconds = compareNPCdata.seconds;
            data.name = name;

            // save as JSON
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.dataPath + "/playerData.json", json);

            SceneManager.LoadScene("MainMenu");
        }
    }
}
