using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelReloader : MonoBehaviour
{
    [SerializeField] private GameObject PlayerDeadPartSystemPrefab;

    public event Action OnDeathSound = delegate { };

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ReloadTimeDelay(other));
        }
    }

    private IEnumerator ReloadTimeDelay(Collider other)
    {
        OnDeathSound();

        other.gameObject.SetActive(false);

        Instantiate(PlayerDeadPartSystemPrefab, other.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}