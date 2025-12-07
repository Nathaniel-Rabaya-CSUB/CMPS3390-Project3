using UnityEngine;

public class newNPC : MonoBehaviour
{
    public bool leave;
    public bool accepted;
    public bool set_random;
    void Start()
    {
        transform.position = new Vector3(-3.25f, 1.5f, -4f);
        leave = false;
        accepted = false;
        set_random = true;
    }

    void Update()
    {

    }
}
