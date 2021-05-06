using System.Collections;
using UnityEngine;

public class PanelShouUp : MonoBehaviour
{
    [SerializeField] private GameObject Panel;

    private void Awake() => GetComponent<AnimationOpenDoorScript>().OnPopUpPanel += HandlerPopUpPanel;

    private void HandlerPopUpPanel() => Panel.SetActive(true);
}
