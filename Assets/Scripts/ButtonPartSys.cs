using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPartSys : MonoBehaviour
{
    [SerializeField] private ParticleSystem ButtonPartSysPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AnimationOpenDoorScript>().OnPartSysShow += HandlerPartSysShow;
    }

    private void HandlerPartSysShow()
    {
        Instantiate(ButtonPartSysPrefab, transform.position, Quaternion.identity);
    }
}
