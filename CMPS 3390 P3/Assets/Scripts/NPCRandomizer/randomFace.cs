using UnityEngine;

public class randomFace : MonoBehaviour
{
    public Sprite[] sprites;
    public randomStructure structureChange;
    public int faceIndex;
    public bool updateHair;

    void Start()
    {
        updateHair = false;

        faceIndex = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[faceIndex];
    }
    void Update()
    {
        if (structureChange.updateFace == true)
        {
            faceIndex = Random.Range(0, sprites.Length);
            GetComponent<SpriteRenderer>().sprite = sprites[faceIndex];
            updateHair = true;
            structureChange.updateFace = false;
        }
    }
}