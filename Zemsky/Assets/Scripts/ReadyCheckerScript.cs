using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyCheckerScript : MonoBehaviour
{
    private int playersReadyCount = 0;

    private void Start()
    {
        CharMenuInputManager.OnReadyPressed += OnReadyPressed;
    }

    private void OnReadyPressed(GameObject presser)
    {
        playersReadyCount++;
        if (playersReadyCount == 2)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
