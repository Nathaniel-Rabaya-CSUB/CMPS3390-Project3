using UnityEngine;
using UnityEngine.PlayerLoop;

public class randomAccessory : MonoBehaviour
{
    public Sprite[] sprites;
    public randomHair hairChange;
    public int accessoryIndex;

    void Start()
    {
        accessoryIndex = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[accessoryIndex];
    }
    void Update()
    {
        if (hairChange.updateAccessory == true)
        {
            accessoryIndex = Random.Range(0, sprites.Length);
            GetComponent<SpriteRenderer>().sprite = sprites[accessoryIndex];
            hairChange.updateAccessory = false;
        }
    }
}
