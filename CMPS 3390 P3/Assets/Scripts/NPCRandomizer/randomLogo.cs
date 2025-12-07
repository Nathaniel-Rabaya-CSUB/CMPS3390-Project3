using UnityEngine;

public class randomLogo : MonoBehaviour
{
    public Sprite[] sprites;
    public int logoIndex;
    void Start()
    {
        logoIndex = Random.Range(0,sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[logoIndex];
    }
}
