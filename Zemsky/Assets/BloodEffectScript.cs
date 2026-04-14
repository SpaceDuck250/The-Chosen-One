using UnityEngine;

public class BloodEffectScript : MonoBehaviour
{
    public HealthScript playerHealthScript;

    public Animator bloodStainAnimator;

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
        if (healthInfo.healthChangeAmount < 0 && healthInfo.currentHealth > 0)
        {
            bloodStainAnimator.SetTrigger("Fade");
        }
    }
}
