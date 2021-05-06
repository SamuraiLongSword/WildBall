using System;
using UnityEngine;

public class BlockActivator : MonoBehaviour
{
    [SerializeField] private GameObject HaloEffetorGO;

    public event Action OnActivated = delegate { };
    public event Action OnBlockSound = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == gameObject.tag)
        {
            HaloEffetorGO.SetActive(true);
            OnActivated();
            OnBlockSound();
        }
    }
}
