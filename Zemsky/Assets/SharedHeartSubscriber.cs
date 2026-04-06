using UnityEngine;

public class SharedHeartSubscriber : MonoBehaviour
{
    public HealthScript sharedHeartHealthScript;

    private void Start()
    {
        GameManager.OnGameEnd += OnGameEnd;
    }

    private void OnDestroy()
    {
        GameManager.OnGameEnd -= OnGameEnd;
    }

    private void OnGameEnd(bool gameWon)
    {
        print("heal to full");
        sharedHeartHealthScript.SetHealth(sharedHeartHealthScript.maxHealth);
    }
}
