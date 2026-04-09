using UnityEngine;

public class HealthBarSubscriber : MonoBehaviour
{
    public GameObject healthBarObj;

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

    private void OnMapLevelStart(MapLevelData mapLevelData)
    {
        healthBarObj.SetActive(true);
    }

    private void OnGameEnd(bool gameWon)
    {
        healthBarObj.SetActive(false);

    }
}
