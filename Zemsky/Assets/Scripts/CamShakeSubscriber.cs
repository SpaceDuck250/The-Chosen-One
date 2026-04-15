using UnityEngine;

public class CamShakeSubscriber : MonoBehaviour
{
    public HealthScript playerHealthScript;
    public CameraShakeScript camShake;


    private void Start()
    {
        playerHealthScript.OnHealthChanged += OnTakeDamage;
    }

    private void OnDestroy()
    {
        playerHealthScript.OnHealthChanged -= OnTakeDamage;

    }

    private void OnTakeDamage(HealthInfo healthInfo)
    {
        if (healthInfo.healthChangeAmount < 0 && healthInfo.currentHealth != 0)
        {
            camShake.StartShake();
        }
    }
}
