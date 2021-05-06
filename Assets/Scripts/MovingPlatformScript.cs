using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    [SerializeField] private bool MovingRevers;
    [SerializeField] private float Speed = 2f;

    private Vector3 _startPosition;
    private float _amplitude = 10f;
    private float _direction;

    private void Awake()
    {
        _startPosition = transform.localPosition;
        _direction = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x >= _startPosition.x + _amplitude/2 ||
           transform.position.x <= _startPosition.x - _amplitude / 2)
        {
            MovingRevers = !MovingRevers;
        }

        if (MovingRevers)
        {
            _direction = 1;
        }
        else
        {
            _direction = -1;
        }

        float OffsetX = Speed * _direction * Time.deltaTime;

        Vector3 Move = Vector3.right * OffsetX;
        transform.Translate(Move);
    }
}
