using Unity.VisualScripting;
using UnityEngine;

public class AlertOnDeath : MonoBehaviour
{
    private MobGroupScript mobGroupScript;

    public HealthScript healthScript;

    private void Start()
    {
        mobGroupScript = transform.parent.GetComponent<MobGroupScript>();
        if (healthScript != null)
        {
            healthScript.OnDeath += OnDeath;

        }
    }

    private void OnDestroy()
    {
        if (healthScript != null)
        {
            healthScript.OnDeath -= OnDeath;

        }

    }

    private void OnDeath(HealthInfo healthInfo)
    {
        AlertMobCounter();
    }

    public void AlertMobCounter()
    {
        if (mobGroupScript == null)
        {
            return;
        }

        mobGroupScript.OnMobDefeated?.Invoke();
    }

}
