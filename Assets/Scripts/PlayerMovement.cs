using UnityEngine;
using System;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float JumpForce = 150f;

    private PlayerInput _playerInput;
    private Rigidbody _rB;
    private bool _isGrounded;

    public event Action OnJumpSound = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovevementLogic();
        JumpLogic();
    }

    private void MovevementLogic()
    {
        Vector3 moveForward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        Vector3 moveRight = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized;

        if (_playerInput.GetVertical > 0)
        {
            _rB.AddForce(moveForward * Speed); // Move forward
        }

        if (_playerInput.GetVertical < 0)
        {
            _rB.AddForce(-moveForward * Speed); // Move back
        }

        if (_playerInput.GetHorizontal < 0)
        {
            _rB.AddForce(-moveRight * Speed); // Move left
        }

        if (_playerInput.GetHorizontal > 0)
        {
            _rB.AddForce(moveRight * Speed); // Move right
        }
    }

    private void JumpLogic()
    {
        if (_playerInput.GetJump > 0)
        {
            if (_isGrounded)
            {
                OnJumpSound();
                _rB.AddForce(Vector3.up * JumpForce);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsGrounded(collision, true);
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGrounded(collision, false);
    }

    private void IsGrounded(Collision collision, bool value)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = value;
        }
    }
}
