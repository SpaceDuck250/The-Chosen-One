using UnityEngine;
using System;

public class MobGroupScript : MonoBehaviour
{
    public Action OnMobDefeated;

    public int mobsLeft;

    private void Start()
    {
        mobsLeft = transform.childCount;

        OnMobDefeated += CheckIfAllMobsDefeated;
    }

    private void OnDestroy()
    {
        OnMobDefeated -= CheckIfAllMobsDefeated;
    }

    private void CheckIfAllMobsDefeated()
    {
        mobsLeft--;
        if (mobsLeft == 0)
        {
            float smallWaitTime = 0.5f;
            Invoke("FinishMobObstacle", smallWaitTime);
        }
    }

    private void FinishMobObstacle()
    {
        ObstacleSpawnerScript.OnObstacleFinished?.Invoke();
        Destroy(gameObject);


    }
}
