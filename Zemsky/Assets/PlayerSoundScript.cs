using UnityEngine;

public class PlayerSoundScript : MonoBehaviour
{
    public SoundManagerScript soundManager;
    public HealthScript playerHealth;

    private void Start()
    {
        soundManager = SoundManagerScript.instance;

        playerHealth.OnHealthChanged += OnHealthChanged;

        PlayerShootScript.OnAnyShot += OnShoot;
        
    }


    private void OnDestroy()
    {
        playerHealth.OnHealthChanged -= OnHealthChanged;

        PlayerShootScript.OnAnyShot -= OnShoot;

    }

    private void OnHealthChanged(HealthInfo healthInfo)
    {
        if (healthInfo.healthChangeAmount < 0)
        {
            soundManager.PlayEffect(soundManager.hurtClip);
        }
    }

    private void OnShoot()
    {
        soundManager.PlayEffect(soundManager.shootClip);
    }
}
