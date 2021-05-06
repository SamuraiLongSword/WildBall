using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
        }
    }
}
