using UnityEngine;

public class randomStructure : MonoBehaviour
{
    public Sprite[] sprites;
    public newNPC updateNPC;
    public int structureIndex;
    public bool updateFace;
    public bool updateClothes;

    void Start()
    {
        updateFace = false;
        updateClothes = false;

        structureIndex = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[structureIndex];
    }
    void Update()
    {
        if (updateNPC.set_random == true)
        {
            structureIndex = Random.Range(0, sprites.Length);
            GetComponent<SpriteRenderer>().sprite = sprites[structureIndex];
            updateFace = true;
            updateClothes = true;
            updateNPC.set_random = false;
        }
    }
}
