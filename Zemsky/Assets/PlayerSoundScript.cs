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
        if (soundManager == null)
        {
            return;
        }

        if (healthInfo.healthChangeAmount < 0)
        {
            soundManager.PlayEffect(soundManager.hurtClip);
        }
    }

    private void OnShoot()
    {
        if (soundManager == null)
        {
            return;
        }

        soundManager.PlayEffect(soundManager.shootClip);
    }
}
