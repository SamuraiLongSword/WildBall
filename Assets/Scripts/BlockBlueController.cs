using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBlueController : MonoBehaviour
{
    [SerializeField] private ObeliskItemCreator Obelisk;
    [SerializeField] private GameObject GoToBlueCanvasPanel;
    [SerializeField] private GameObject FinishLevelGO;

    private Animator _anim;
    private bool _isActive;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        Obelisk.OnAllActivated += HandleAllActivated;
        _isActive = true;
    }

    private void HandleAllActivated()
    {
        GoToBlueCanvasPanel.SetActive(true);
        _isActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isActive)
        {
            GoToBlueCanvasPanel.SetActive(false);
            _anim.SetTrigger("IsAllActivated");
            _isActive = true;

            StartCoroutine(SetActiveGate());
        }
    }

    private IEnumerator SetActiveGate()
    {
        yield return new WaitForSeconds(2);
        FinishLevelGO.SetActive(true);
    }
}
