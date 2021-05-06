using UnityEngine;

public class PlayerChilding : MonoBehaviour
{
    private GameObject _platform;

    // Update is called once per frame
    void Update()
    {
        if(_platform != null)
        {
            transform.parent = _platform.transform;
        }
        else
        {
            transform.parent = GameObject.Find("Environment").transform;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MovingPlatformScript>() != null)
        {
            _platform = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<MovingPlatformScript>() != null)
        {
            _platform = null;
        }
    }
}
