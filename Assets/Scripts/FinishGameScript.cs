using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGameScript : MonoBehaviour
{
    [SerializeField] private GameObject FinishSalutPrefab;
    [SerializeField] private GameObject FinishGameTMPPrefab;

    public event Action OnFinishGame = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FinishGameTMPPrefab.SetActive(true);
            FinishSalutPrefab.SetActive(true);
            OnFinishGame();

            StartCoroutine(EndGame());
        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(0);
    }
}
