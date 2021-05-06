using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2CanvasStart : MonoBehaviour
{
    [SerializeField] private GameObject StartLevelPopUp;

    // Start is called before the first frame update
    void Start()
    {
        StartLevelPopUp.SetActive(true);

        StartCoroutine(ClosePopUp());
    }

    private IEnumerator ClosePopUp()
    {
        yield return new WaitForSeconds(5);

        StartLevelPopUp.SetActive(false);
    }
}
