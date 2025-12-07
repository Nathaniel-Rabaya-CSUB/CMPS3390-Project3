using UnityEngine;

public class randomClothingArms : MonoBehaviour
{
    public Sprite[] sprites;
    public randomClothing randCloth;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[randCloth.clothNum];
    }
    void Update()
    {
        if (randCloth.updateArms == true)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[randCloth.clothNum];
            randCloth.updateArms = false;
        }
    }
}
