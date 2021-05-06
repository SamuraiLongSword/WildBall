using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject PlayerDeadPartSystemPrefab;
    [SerializeField] private SoundManager SoundManager;

    public event Action OnDeathSound = delegate { };

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(ReloadTimeDelay(collision));
        }
    }

    private IEnumerator ReloadTimeDelay(Collision collision)
    {
        SoundManager.DeathSound();

        collision.gameObject.SetActive(false);

        Instantiate(PlayerDeadPartSystemPrefab, collision.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
