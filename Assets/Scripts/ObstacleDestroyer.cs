using System;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    public event Action OnObstaclesActivated = delegate { };

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnObstaclesActivated();
        }
    }
}
