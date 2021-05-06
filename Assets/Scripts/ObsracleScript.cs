using UnityEngine;

public class ObsracleScript : MonoBehaviour
{
    void Start()
    {
        float R = Random.value;
        float G = Random.value;
        float B = Random.value;

        GetComponent<Renderer>().material.color = new Color(R, G, B);
    }
}
