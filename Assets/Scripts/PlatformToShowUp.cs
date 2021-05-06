using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformToShowUp : MonoBehaviour
{
    [SerializeField] private GameObject PlatformToShowUpPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlatformToShowUpPrefab.SetActive(true);
        }
    }
}
