using UnityEngine;

public class SharedHeartSubscriber : MonoBehaviour
{
    public HealthScript sharedHeartHealthScript;
    public SharedHeartScript sharedHeartScript;

    private void Start()
    {
        ShrineScript.OnMapLevelStart += OnMapLevelStart;
        GameManager.OnGameEnd += OnGameEnd;
    }

    private void OnDestroy()
    {
        ShrineScript.OnMapLevelStart -= OnMapLevelStart;
        GameManager.OnGameEnd -= OnGameEnd;
    }

    private void OnGameEnd(bool gameWon)
    {
        print("heal to full");
        sharedHeartHealthScript.SetHealth(sharedHeartHealthScript.maxHealth);
        sharedHeartScript.FollowNobody();
    }

    private void OnMapLevelStart(MapLevelData mapLevelData)
    {
        sharedHeartHealthScript.SetHealth(sharedHeartHealthScript.maxHealth);

    }
}
