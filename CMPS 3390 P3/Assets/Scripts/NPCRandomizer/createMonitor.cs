using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class createMonitor : MonoBehaviour
{
    // reference to another script
    public compareNPCdata NPC;
    public createNPC newNPC;

    // set game object variables
    public GameObject StructureMON;
    public GameObject FaceMON;
    public GameObject HairMON;
    public GameObject AccessoryMON;

    // set sprite arrays
    public Sprite[] S_sprites;
    public Sprite[] F_sprites;
    public Sprite[] H_sprites;
    public Sprite[] A_sprites;

    // set sprite indices
    public int structureIdx;
    public int faceIdx;
    public int hairIdx;
    public int accessoryIdx;

    void Start()
    {
        // assign game object variables
        StructureMON = GameObject.Find("/Monitor/structure");
        FaceMON = GameObject.Find("/Monitor/face");
        HairMON = GameObject.Find("/Monitor/hair");
        AccessoryMON = GameObject.Find("/Monitor/accessory");
    }

    void Update()
    {
        if (newNPC.changeMonitor == true)
        {
            // randomize between same or different NPC to Monitor Sprites
            int sameDifferent = Random.Range(0, 2);

            // update Sprites to be same as NPC
            if (sameDifferent == 0)
            {
                // sets internal index == external index
                // easier comparison
                structureIdx = newNPC.structureIdx;
                faceIdx = newNPC.faceIdx;
                hairIdx = newNPC.hairIdx;
                accessoryIdx = newNPC.accessoryIdx;

                // Monitor == NPC
                setSame(StructureMON, ref structureIdx, newNPC.S_sprites);
                setSame(FaceMON, ref faceIdx, newNPC.F_sprites);
                setSame(HairMON, ref hairIdx, newNPC.H_sprites);
                setSame(AccessoryMON, ref accessoryIdx, newNPC.A_sprites);
            }

            // update Sprites to be different from NPC
            else
            {
                // Monitor != NPC
                setDifferent(StructureMON, ref structureIdx, newNPC.S_sprites);
                setDifferent(FaceMON, ref faceIdx, newNPC.F_sprites);
                setDifferent(HairMON, ref hairIdx, newNPC.H_sprites);
                setDifferent(AccessoryMON, ref accessoryIdx, newNPC.A_sprites);
            }

            // reset monitor lock
            newNPC.changeMonitor = false;
        }
    }

    void setSame(GameObject obj, ref int idx, Sprite[] sprite)
    {
        obj.GetComponent<SpriteRenderer>().sprite = sprite[idx];
    }

    void setDifferent(GameObject obj, ref int idx, Sprite[] sprite)
    {
        idx = Random.Range(0, sprite.Length); // get random index
        obj.GetComponent<SpriteRenderer>().sprite = sprite[idx]; // assign sprite based on index
    }
}
