using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public AudioSource musicSrc, effectsSrc;

    public AudioClip grassAreaBgm, templeBgm;

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
