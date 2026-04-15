using UnityEngine;

public class ObstacleSubscriber : MonoBehaviour
{
    public ObstacleSpawnerScript obstacleSpawner;

    public MapLevelData mainSelectorAreaMap;

    private void Start()
    {
        ObstacleSpawnerScript.OnObstacleFinished += OnObstacleFinished;
        ShrineScript.OnMapLevelStart += OnMapLevelStart;

        GameManager.OnGameEnd += OnGameEnd;
    }

    private void OnDestroy()
    {
        ObstacleSpawnerScript.OnObstacleFinished -= OnObstacleFinished;
        ShrineScript.OnMapLevelStart += OnMapLevelStart;

        GameManager.OnGameEnd -= OnGameEnd;
    }

    private void OnObstacleFinished()
    {
        obstacleSpawner.SpawnNextObstacle();
    }

    private void OnMapLevelStart(MapLevelData mapData)
    {
        obstacleSpawner.ChangeMapLevelData(mapData);
    }

    private void OnGameEnd(bool gameWon)
    {
        //obstacleSpawner.StopAllObstacles();
        obstacleSpawner.ChangeMapLevelData(mainSelectorAreaMap);
        print("Ended");
    }
}


