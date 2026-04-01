using UnityEngine;

public class ObstacleFinisherScript : MonoBehaviour
{
    public float finishTime;

    private void Start()
    {
        Invoke("FinishObstacle", finishTime);
    }

    private void FinishObstacle()
    {
        ObstacleSpawnerScript.OnObstacleFinished?.Invoke();
    }
}
