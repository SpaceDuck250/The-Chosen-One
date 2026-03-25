using UnityEngine;
using System;
using System.Collections.Generic;
using Edge;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public System.Action OnObstacleFinished;

    public ObstacleLevelData currentObstacleLevelData;
    public List<ObstacleData> obstaclesToSpawnList;

    private int obstaclePointer = 0;

    public Transform obstacleContainer;

    public void ChangeObstacleLevelData(ObstacleLevelData newLevelData)
    {
        currentObstacleLevelData = newLevelData;
        obstaclesToSpawnList.Clear();
        obstaclesToSpawnList = currentObstacleLevelData.obstaclesList;
    }

    public void SpawnNextObstacle()
    {
        if (obstaclePointer >= obstaclesToSpawnList.Count)
        {
            return;
        }

        ObstacleData obstacleData = obstaclesToSpawnList[obstaclePointer];
        SpawnObstacle(obstacleData);

        obstaclePointer++;
    }

    public void SpawnObstacle(ObstacleData obstacleData)
    {
        Vector2 spawnPosition = obstacleData.spawnPosition;
            
        GameObject newObstacle = Instantiate(obstacleData.obstacleObj, spawnPosition, Quaternion.identity, obstacleContainer);
    }

}
