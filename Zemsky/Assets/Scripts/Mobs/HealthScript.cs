using UnityEngine;
using System;

public class HealthScript : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public event Action<HealthInfo> OnHealthChanged;
    public event Action<HealthInfo> OnDeath;

    // for sounds and effects
    public static event Action<HealthInfo> OnAnyHealthChanged;
    public static event Action<HealthInfo> OnAnyDeath;

    public GameObject owner;
     
    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health += damage;

        CheckIfDied(damage);

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        HealthInfo healthInfo = CreateNewHealthInfo(damage);
        OnAnyHealthChanged?.Invoke(healthInfo);
        OnHealthChanged?.Invoke(healthInfo);
    }

    public void SetHealth(float newHealth)
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
            CheckIfDied(0);
        }
        else
        {
            health = newHealth;
        }

        HealthInfo healthInfo = CreateNewHealthInfo(0);
        OnAnyHealthChanged?.Invoke(healthInfo);
        OnHealthChanged?.Invoke(healthInfo);
    }

    private HealthInfo CreateNewHealthInfo(float healthChangeAmount)
    {
        HealthInfo healthInfo = new HealthInfo
        {
            currentHealth = health,
            maxHealth = maxHealth,
            healthChangeAmount = healthChangeAmount,
            owner = gameObject
        };

        return healthInfo;
    }

    private void CheckIfDied(float damage)
    {
        if (health <= 0)
        {
            health = 0;

            HealthInfo deathHealthInfo = CreateNewHealthInfo(damage);
            OnAnyDeath?.Invoke(deathHealthInfo);
            OnDeath?.Invoke(deathHealthInfo);

            //Comment out later
            //Destroy(owner);
        }
    }
}
