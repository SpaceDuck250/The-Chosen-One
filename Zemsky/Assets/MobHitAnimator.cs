using UnityEngine;

public class MobHitAnimator : MonoBehaviour
{
    public Animator animator;
    public HealthScript healthScript;

    private void Start()
    {
        healthScript.OnHealthChanged += OnTakeDamage;
    }


    private void OnDestroy()
    {
        healthScript.OnHealthChanged -= OnTakeDamage;


    }

    private void OnTakeDamage(HealthInfo healthInfo)
    {
        if (healthInfo.healthChangeAmount < 0 && healthInfo.currentHealth > 0)
        {
            animator.SetTrigger("hit");
        }
    }
}
