using System.Collections;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyGO());
        }
    }

    private IEnumerator DestroyGO()
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }
}
