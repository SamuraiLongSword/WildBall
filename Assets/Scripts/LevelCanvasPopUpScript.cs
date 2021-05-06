using UnityEngine;

public class LevelCanvasPopUpScript : MonoBehaviour
{
    [SerializeField] private GameObject PopUpPanelGate;
    [SerializeField] private GameObject PopUpPanelButton;
    [SerializeField] private GameObject PopUpPanelOvelisk;

    private AnimationOpenDoorScript[] _allDoorsExemplars;

    private void Awake()
    {
        _allDoorsExemplars = FindObjectsOfType<AnimationOpenDoorScript>();

        foreach (var e in _allDoorsExemplars)
        {
            e.OnPressButtonMessageShow += HandlePressButtonMessageShow;
            e.OnPressButtonMessageUnshow += HandlePressButtonMessageUnshow;
        }
    }

    private void HandlePressButtonMessageShow(GameObject objWithTag)
    {
        if(objWithTag.tag == "Gate")
        {
            PopUpPanelGate.SetActive(true);
        }

        if (objWithTag.tag == "Button")
        {
            PopUpPanelButton.SetActive(true);
        }

        if (objWithTag.tag == "Obelisk")
        {
            PopUpPanelOvelisk.SetActive(true);
        }
    }

    private void HandlePressButtonMessageUnshow(GameObject objWithTag)
    {
        if (objWithTag.tag == "Gate")
        {
            PopUpPanelGate.SetActive(false);
        }

        if (objWithTag.tag == "Button")
        {
            PopUpPanelButton.SetActive(false);
        }

        if (objWithTag.tag == "Obelisk")
        {
            PopUpPanelOvelisk.SetActive(false);
        }
    }
}
