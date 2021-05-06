using System;
using UnityEngine;

public class ObeliskItemCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] SphereKeyPrefabs;

    private int _createCounter;
    private bool _isCreated;
    private BlockActivator[] Blocks;
    private AnimationOpenDoorScript _aODS;

    public event Action OnAllActivated = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AnimationOpenDoorScript>().OnObeliskItem += HendleObeliskItem;
        _createCounter = 0;
        _isCreated = false;

        Blocks = FindObjectsOfType<BlockActivator>();
        foreach(var e in Blocks)
        {
            e.OnActivated += HandleAcrivated;
        }

        _aODS = GetComponent<AnimationOpenDoorScript>();
    }

    private void HandleAcrivated()
    {
        _isCreated = !_isCreated;
        if(_createCounter < SphereKeyPrefabs.Length)
        {
            _aODS.Changer();
        }

        if (_createCounter == 3)
        {
            OnAllActivated();
        }
    }

    private void HendleObeliskItem()
    {
        if (!_isCreated && _createCounter < SphereKeyPrefabs.Length)
        {
            Instantiate(SphereKeyPrefabs[_createCounter], transform.position, Quaternion.identity);
            _isCreated = !_isCreated;
            _createCounter++;
        }
    }
}
