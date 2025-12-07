using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newNPC : MonoBehaviour
{
    public int check;
    public bool set_random;
    public int score;

    public compareNPCdata Compare;

    void Start()
    {
        score = 0;
        check = 0;
        set_random = false;
    }

    void Update() // check == 0 -> wait for player input
    {
        // player was correct
        if (check == 1)
        {
            score++;
            set_random = true;
            check = 0;
        }

        // player was incorrect
        if (check == 2)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
