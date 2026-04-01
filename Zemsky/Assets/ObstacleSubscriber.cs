using UnityEngine;

public class ObstacleSubscriber : MonoBehaviour
{
    public ObstacleSpawnerScript obstacleSpawner;

    private void Start()
    {
        ObstacleSpawnerScript.OnObstacleFinished += OnObstacleFinished;
        ShrineScript.OnMapLevelStart += OnMapLevelStart;
    }

    private void OnDestroy()
    {
        ObstacleSpawnerScript.OnObstacleFinished -= OnObstacleFinished;
        ShrineScript.OnMapLevelStart += OnMapLevelStart;
    }

    private void OnObstacleFinished()
    {
        obstacleSpawner.SpawnNextObstacle();
    }

    private void OnMapLevelStart(MapLevelData mapData)
    {
        obstacleSpawner.ChangeMapLevelData(mapData);
    }
}


