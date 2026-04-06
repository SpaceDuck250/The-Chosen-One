using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{
    private void Start()
    {
        ShrineScript.OnMapLevelStart += OnMapLevelStart;
    }

    private void OnDestroy()
    {
        ShrineScript.OnMapLevelStart -= OnMapLevelStart;

    }

    private void OnMapLevelStart(MapLevelData mapLevelData)
    {
        if (DontDestroyScript.instance == null)
        {
            return;
        }

        SoundManagerScript soundManager = DontDestroyScript.instance.transform.Find("SoundManager").GetComponent<SoundManagerScript>();
        soundManager.PlayMusic(soundManager.templeBgm);
    }

    
}
