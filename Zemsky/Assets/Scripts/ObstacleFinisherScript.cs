using UnityEngine;

public class ObstacleFinisherScript : MonoBehaviour
{
    public float finishTime;

    private float timer;

    private bool finished = false;

    private void Update()
    {
        if (finished)
        {
            return;
        }

        timer += Time.deltaTime;
        Debug.Log("Counting " + gameObject);
        if (timer >= finishTime)
        {
            FinishObstacle();
            finished = true;
        }
    }

    private void FinishObstacle()
    {
        ObstacleSpawnerScript.OnObstacleFinished?.Invoke();
        Debug.Log("Finished An Obstacle");
    }
}
