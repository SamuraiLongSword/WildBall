using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class AnimationOpenDoorScript : MonoBehaviour
{
    private Animator _animatorComponent;
    private PlayerInput _playerInput;
    private bool _isDoorClosed;    

    public event Action<GameObject> OnPressButtonMessageShow = delegate { };
    public event Action<GameObject> OnPressButtonMessageUnshow = delegate { };
    public event Action OnPopUpPanel = delegate { };
    public event Action OnObeliskItem = delegate { };
    public event Action OnPartSysShow = delegate { };
    public event Action OnButtonSound = delegate { };

    private void Awake()
    {
        _animatorComponent = GetComponent<Animator>();

        GameObject player = GameObject.Find("Player");
        _playerInput = player.GetComponent<PlayerInput>();

        _isDoorClosed = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.tag == "Obelisk" && other.gameObject.tag == "Player" && _playerInput.EButton && _isDoorClosed)
        {
            _isDoorClosed = false;
            OnPressButtonMessageUnshow(gameObject);
            OnObeliskItem();
            OnButtonSound();
            return;
        }

        if (other.gameObject.tag == "Player" && _playerInput.EButton && _isDoorClosed)
        {
            _animatorComponent.SetTrigger("IfButtonPressed");
            _isDoorClosed = false;
            OnPressButtonMessageUnshow(gameObject);
            OnPopUpPanel();
            OnPartSysShow();
            OnButtonSound();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _isDoorClosed)
        {
            OnPressButtonMessageShow(gameObject);
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && _isDoorClosed)
        {
            OnPressButtonMessageUnshow(gameObject);
        }        
    }

    public void Changer()
    {
        _isDoorClosed = !_isDoorClosed;
    }
}
