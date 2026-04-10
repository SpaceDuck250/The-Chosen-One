using UnityEngine;
using System;
using System.Collections.Generic;
using Edge;
using System.Collections;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public static System.Action OnObstacleFinished;

    public MapLevelData currentMapLevelData;
    public List<ObstacleData> obstaclesToSpawnList = new List<ObstacleData>();

    private int obstaclePointer = 0;

    public Transform obstacleContainer;

    public float waitTimeUntilSpawnFirstObstacle;
    public float waitTimeUntilWin;

    public void ChangeMapLevelData(MapLevelData newLevelData)
    {
        StopAllCoroutines();

        StopAllObstacles();

        obstaclePointer = 0;

        currentMapLevelData = newLevelData;
        obstaclesToSpawnList.Clear();

        if (newLevelData != null && newLevelData.obstacleList.Count > 0)
        {
            foreach (var obstacle in newLevelData.obstacleList)
            {
                obstaclesToSpawnList.Add(obstacle);
            }

            StartCoroutine(waitUntilSpawnNextObstacle());
        }
        
        
    }

    public IEnumerator waitUntilSpawnNextObstacle()
    {
        yield return new WaitForSeconds(waitTimeUntilSpawnFirstObstacle);
        SpawnNextObstacle();
    }

    public void SpawnNextObstacle()
    {
        if (obstaclePointer >= obstaclesToSpawnList.Count && obstaclePointer != 0)
        {
            Invoke("SetLevelToWon", waitTimeUntilWin);
            return;
        }
        else if(obstaclePointer >= obstaclesToSpawnList.Count)
        {
            return;
        }


        ObstacleData obstacleData = obstaclesToSpawnList[obstaclePointer];
        SpawnObstacle(obstacleData);

        obstaclePointer++;
    }

    public void SpawnObstacle(ObstacleData obstacleData)
    {
        Vector2 spawnPosition = obstacleData.spawnPosition + currentMapLevelData.cameraCenterPosition;
            
        GameObject newObstacle = Instantiate(obstacleData.obstacleObj, spawnPosition, Quaternion.identity, obstacleContainer);
    }

    public void StopAllObstacles()
    {

        foreach (Transform obstacle in obstacleContainer)
        {
            Destroy(obstacle.gameObject);
        }
    }

    public void SetLevelToWon()
    {
        GameManager.OnGameEnd?.Invoke(true);
    }

}
