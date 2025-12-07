using UnityEngine;

public class randomHair : MonoBehaviour
{
    public Sprite[] sprites;
    public randomFace faceChange;
    public int hairIndex;
    public bool updateAccessory;

    void Start()
    {
        updateAccessory = false;

        hairIndex = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[hairIndex];
    }
    void Update()
    {
        if (faceChange.updateHair == true)
        {
            hairIndex = Random.Range(0, sprites.Length);
            GetComponent<SpriteRenderer>().sprite = sprites[hairIndex];
            updateAccessory = true;
            faceChange.updateHair = false;
        }
    }
}
