using UnityEngine;

public class HeartAnimatorScript : MonoBehaviour
{
    public HealthScript healthScript;
    public Animator heartAnimator;

    private void Start()
    {
        healthScript.OnHealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        healthScript.OnHealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(HealthInfo healthInfo)
    {
        if (healthInfo.healthChangeAmount > 0)
        {
            return;
        }

        heartAnimator.SetTrigger("OnDamage");
    }
}
