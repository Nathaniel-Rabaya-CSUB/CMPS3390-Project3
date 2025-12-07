using UnityEngine;

public class randomClothing : MonoBehaviour
{
    public Sprite[] sprites;
    public randomStructure changeNPC;
    public int clothNum;
    public bool updateArms;

    void Start()
    {
        updateArms = false;

        clothNum = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[clothNum];
    }
    void Update()
    {
        if (changeNPC.updateClothes == true)
        {
            clothNum = Random.Range(0, sprites.Length);
            GetComponent<SpriteRenderer>().sprite = sprites[clothNum];
            updateArms = true;
            changeNPC.updateClothes = false;
        }
    }
}
