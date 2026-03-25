using UnityEngine;

public class ObstacleSubscriber : MonoBehaviour
{
    public ObstacleSpawnerScript obstacleSpawner;

    private void Start()
    {
        obstacleSpawner.OnObstacleFinished += OnObstacleFinished;
    }

    private void OnDestroy()
    {
        obstacleSpawner.OnObstacleFinished -= OnObstacleFinished;

    }

    private void OnObstacleFinished()
    {
        obstacleSpawner.SpawnNextObstacle();
    }
}


