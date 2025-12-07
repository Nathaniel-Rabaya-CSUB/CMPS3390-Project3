using UnityEngine;

public class compareNPCdata : MonoBehaviour
{
    public bool structure_pass;
    public bool face_pass;
    public bool hair_pass;
    public bool accessory_pass;

    public GameObject StructureNPC;
    public GameObject FaceNPC;
    public GameObject HairNPC;
    public GameObject AccessoryNPC;

    public GameObject StructureMon;
    public GameObject FaceMon;
    public GameObject HairMon;
    public GameObject AccessoryMon;

    public int CompareData()
    {
        // set passes to false
        structure_pass = face_pass = hair_pass = accessory_pass = false;

        // set Monitor variables
        StructureMon = GameObject.Find("Monitor/structure");
        FaceMon = GameObject.Find("Monitor/face");
        HairMon = GameObject.Find("Monitor/hair");
        AccessoryMon = GameObject.Find("Monitor/accessory");

        // set NPC Variables
        StructureNPC = GameObject.Find("NPC/structure");
        FaceNPC = GameObject.Find("NPC/face");
        HairNPC = GameObject.Find("NPC/hair");
        AccessoryNPC = GameObject.Find("NPC/accessory");

        // set SpriteRenderer variables
        SpriteRenderer S_Mon_Sprite = StructureMon.GetComponent<SpriteRenderer>();
        SpriteRenderer F_Mon_Sprite = FaceMon.GetComponent<SpriteRenderer>();
        SpriteRenderer H_Mon_Sprite = HairMon.GetComponent<SpriteRenderer>();
        SpriteRenderer A_Mon_Sprite = AccessoryMon.GetComponent<SpriteRenderer>();
        SpriteRenderer S_NPC_Sprite = StructureNPC.GetComponent<SpriteRenderer>();
        SpriteRenderer F_NPC_Sprite = FaceNPC.GetComponent<SpriteRenderer>();
        SpriteRenderer H_NPC_Sprite = HairNPC.GetComponent<SpriteRenderer>();
        SpriteRenderer A_NPC_Sprite = AccessoryNPC.GetComponent<SpriteRenderer>();

        // Compare Mon with NPC
        if (S_Mon_Sprite == S_NPC_Sprite) { structure_pass = true; }
        if (F_Mon_Sprite == F_NPC_Sprite) { face_pass = true; }
        if (H_Mon_Sprite == H_NPC_Sprite) { hair_pass = true; }
        if (A_Mon_Sprite == A_NPC_Sprite) { accessory_pass = true; }

        if (structure_pass == face_pass == hair_pass == accessory_pass == true) { return 1; } // NPC and Monitor are the same
        else { return 2; } // NPC and Monitor are NOT the same
    }
}
