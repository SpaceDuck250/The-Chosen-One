using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public AudioSource musicSrc, effectsSrc;

    public AudioClip grassAreaBgm, templeBgm;

    public AudioClip shootClip, hurtClip, boomClip, throwClip;

    public static SoundManagerScript instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        PlayMusic(grassAreaBgm);
    }

    public void PlayMusic(AudioClip musicClip)
    {
        musicSrc.loop = true;
        musicSrc.clip = musicClip;
        musicSrc.Play();
    }

    public void PlayEffect(AudioClip soundEffect)
    {
        effectsSrc.PlayOneShot(soundEffect);
    }
}
