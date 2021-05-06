using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject _player;
    private Transform _playerPosition;
    private PlayerInput _playerInput;
    private Vector3 _offset;
    private float _rotY;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerPosition = _player.GetComponent<Transform>();
        _offset = transform.position - _playerPosition.position;
        _rotY = transform.eulerAngles.y;

        _playerInput = _player.GetComponent<PlayerInput>();
    }

    private void LateUpdate()
    {
        #region Moving without mouse dragging
        //// Moving without mouse dragging
        //if (_playerInput.MouseLeft)
        //{
        //    _rotY -= _playerInput.GetFire1;
        //}

        //if (_playerInput.MouseRight)
        //{
        //    _rotY += _playerInput.GetFire2;
        //}
        #endregion     

        // Moving wiht mouse dragging
        if (_playerInput.MouseRight)
        {
            _rotY += _playerInput.GetMouseX;
        }

        Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
        transform.position = _playerPosition.position + (rotation * _offset);
        transform.LookAt(_playerPosition);
    }
}
