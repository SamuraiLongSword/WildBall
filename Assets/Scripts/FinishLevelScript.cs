using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FinishLevelScript : MonoBehaviour
{
    public event Action OnFinishLvlSound = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            StartCoroutine(LoadNextLevelOffset());
        }
    }

    private IEnumerator LoadNextLevelOffset()
    {
        OnFinishLvlSound();

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
