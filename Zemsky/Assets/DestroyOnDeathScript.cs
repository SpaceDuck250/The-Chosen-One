using UnityEngine;

public class DestroyOnDeathScript : MonoBehaviour
{
    public HealthScript healthScript;

    private void Start()
    {
        healthScript = GetComponent<HealthScript>();
        healthScript.OnDeath += OnDeath;
    }

    private void OnDestroy()
    {
        healthScript.OnDeath -= OnDeath;

    }

    private void OnDeath(HealthInfo healthInfo)
    {
        Destroy(gameObject);
    }
}
