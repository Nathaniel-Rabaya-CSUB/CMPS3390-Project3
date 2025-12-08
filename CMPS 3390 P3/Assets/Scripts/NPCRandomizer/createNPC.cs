using UnityEngine;

public class createNPC : MonoBehaviour
{
    // reference to another script
    public compareNPCdata NPC;

    // set game object variables
    public GameObject StructureNPC;
    public GameObject FaceNPC;
    public GameObject HairNPC;
    public GameObject AccessoryNPC;
    public GameObject Clothing;
    public GameObject TLArm;
    public GameObject TRArm;
    public GameObject BRArm;
    public GameObject BLArm;

    // set sprite arrays
    public Sprite[] S_sprites;
    public Sprite[] F_sprites;
    public Sprite[] H_sprites;
    public Sprite[] A_sprites;
    public Sprite[] C_sprites;
    public Sprite[] TA_sprites;
    public Sprite[] BA_sprites;

    // set sprite indices
    public int structureIdx;
    public int faceIdx;
    public int hairIdx;
    public int accessoryIdx;
    public int clothingIdx;

    void Start()
    {
        // assign game object variables
        StructureNPC = GameObject.Find("/NPC/structure");
        FaceNPC = GameObject.Find("/NPC/face");
        HairNPC = GameObject.Find("/NPC/hair");
        AccessoryNPC = GameObject.Find("/NPC/accessory");
        Clothing = GameObject.Find("/NPC/torso");
        TLArm = GameObject.Find("/NPC/TL arm");
        TRArm = GameObject.Find("/NPC/TR arm");
        BRArm = GameObject.Find("/NPC/BR arm");
        BLArm = GameObject.Find("/NPC/BL arm");

        // set Sprites
        setSprite(StructureNPC, ref structureIdx, S_sprites);
        setSprite(FaceNPC, ref faceIdx, F_sprites);
        setSprite(HairNPC, ref hairIdx, H_sprites);
        setSprite(AccessoryNPC, ref accessoryIdx, A_sprites);
        setSprite(Clothing, ref clothingIdx, C_sprites);

        // set Arm Sprites
        setArmSprite(TLArm, ref clothingIdx, TA_sprites);
        setArmSprite(TRArm, ref clothingIdx, TA_sprites);
        setArmSprite(BRArm, ref clothingIdx, BA_sprites);
        setArmSprite(BLArm, ref clothingIdx, BA_sprites);
    }

    void Update()
    {
        if (NPC.set_random == true)
        {
            // update Sprites
            setSprite(StructureNPC, ref structureIdx, S_sprites);
            setSprite(FaceNPC, ref faceIdx, F_sprites);
            setSprite(HairNPC, ref hairIdx, H_sprites);
            setSprite(AccessoryNPC, ref accessoryIdx, A_sprites);
            setSprite(Clothing, ref clothingIdx, C_sprites);

            // update Arm Sprites
            setArmSprite(TLArm, ref clothingIdx, TA_sprites);
            setArmSprite(TRArm, ref clothingIdx, TA_sprites);
            setArmSprite(BRArm, ref clothingIdx, BA_sprites);
            setArmSprite(BLArm, ref clothingIdx, BA_sprites);

            // reset randomize lock
            NPC.set_random = false;
        }
    }

    void setSprite(GameObject obj, ref int idx, Sprite[] sprite)
    {
        idx = Random.Range(0, sprite.Length); // get random index
        obj.GetComponent<SpriteRenderer>().sprite = sprite[idx]; // assign sprite based on index
    }

    void setArmSprite(GameObject obj, ref int cloth, Sprite[] sprite)
    {
        obj.GetComponent<SpriteRenderer>().sprite = sprite[cloth];
    }
}
