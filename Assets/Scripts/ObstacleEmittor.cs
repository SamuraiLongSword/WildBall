using UnityEngine;

public class ObstacleEmittor : MonoBehaviour
{
    [SerializeField] private GameObject ObstaclePrefab;
    [SerializeField] private ObstacleDestroyer ObstacleDestroyerPrefab;

    private float _obstacleTimer;
    private float _obstacleMaxTime;
    private bool _isActivated;

    // Start is called before the first frame update
    void Start()
    {
        _obstacleTimer = 0;
        _obstacleMaxTime = 1f;
        _isActivated = false;
        ObstacleDestroyerPrefab.OnObstaclesActivated += HandlerActivated;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActivated)
        {
            ObstacleInstantiator();
        }
    }

    private void ObstacleInstantiator()
    {
        _obstacleTimer += Time.deltaTime;

        if(_obstacleTimer > _obstacleMaxTime)
        {
            float X = Random.Range(transform.position.x - 3, transform.position.x + 3);

            Instantiate(ObstaclePrefab, new Vector3(X, transform.position.y, transform.position.z), Quaternion.identity);

            _obstacleTimer = 0;
        }
    }

    private void HandlerActivated()
    {
        _isActivated = true;
    }
}
