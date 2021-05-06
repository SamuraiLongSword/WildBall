using System;
using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
    [SerializeField] private SoundManager SoundManager;

    public event Action OnShieldSound = delegate { };
    public event Action OnPlayerShieldActivated = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnShieldSound();
            OnPlayerShieldActivated();

            Destroy(gameObject);
        }
    }
}
