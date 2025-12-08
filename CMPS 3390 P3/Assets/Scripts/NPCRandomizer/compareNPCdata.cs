using UnityEngine;
using UnityEngine.SceneManagement;

public class compareNPCdata : MonoBehaviour
{
    public createNPC NPC;
    public createMonitor MON;

    public int check;
    public float time;
    public bool set_random;

    public static int score;
    public static int seconds;

    public void Start()
    {
        score = 0;
        check = 0;
        set_random = false;
    }

    void Update() // check == 0 -> wait for player input
    {
        // update time
        time += Time.deltaTime;
        seconds = (int)time % 60;

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

    public int CompareData()
    {
        // all features are the same -> return 1
        if (NPC.structureIdx == MON.structureIdx &&
           NPC.faceIdx == MON.faceIdx &&
           NPC.hairIdx == MON.hairIdx &&
           NPC.accessoryIdx == MON.accessoryIdx) { return 1; }

        // if at least one feature is different -> return 2
        else { return 2; }
    }

    public void AcceptNPC()
    {
        int compareCheck = CompareData();
        if (compareCheck == 1) { check = 1; } // NPC, monitor, and player.accept input DO match
        else { check = 2; } // NPC, monitor, and player.accept input DON'T match
    }

    public void DenyNPC()
    {
        int compareCheck = CompareData();
        if (compareCheck == 2) { check = 1; } // NPC, monitor, and player.accept input DON'T match
        else { check = 2; } // NPC, monitor, and player.accept input DO match
    }
}
