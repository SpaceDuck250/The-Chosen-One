using UnityEngine;
using System;
using System.Collections.Generic;
using Edge;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public static System.Action OnObstacleFinished;

    public MapLevelData currentMapLevelData;
    public List<ObstacleData> obstaclesToSpawnList;

    private int obstaclePointer = 0;

    public Transform obstacleContainer;

    public void ChangeMapLevelData(MapLevelData newLevelData)
    {
        currentMapLevelData = newLevelData;
        obstaclesToSpawnList.Clear();
        obstaclesToSpawnList = currentMapLevelData.obstacleList;

        SpawnNextObstacle();
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
