using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public HealthScript sharedHeartHealthScript;

    public Image healthBarImage;

    private void Start()
    {
        sharedHeartHealthScript.OnHealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        sharedHeartHealthScript.OnHealthChanged -= OnHealthChanged;

    }

    private void OnHealthChanged(HealthInfo healthInfo)
    {
        healthBarImage.fillAmount = healthInfo.currentHealth / healthInfo.maxHealth;
    }
}
