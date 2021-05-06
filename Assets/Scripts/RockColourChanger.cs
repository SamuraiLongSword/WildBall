using UnityEngine;

public class RockColourChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
