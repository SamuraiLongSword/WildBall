using UnityEngine;

public class PlayerShieldActivator : MonoBehaviour
{
    [SerializeField] private ShieldPickUp Shield;
    [SerializeField] private GameObject ShieldPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Shield.OnPlayerShieldActivated += HandlerActivator;
    }

    private void HandlerActivator()
    {
        ShieldPrefab.SetActive(true);
    }
}
