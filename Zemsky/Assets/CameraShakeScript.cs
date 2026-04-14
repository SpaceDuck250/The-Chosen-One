using UnityEditor.Rendering;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    public float offsetValue;

    public Camera cam;

    public ObstacleSpawnerScript obstacleSpawner;

    private float repeatTimer;
    public float repeatTime;

    private float generalTimer;
    public float generalTime;

    public bool shake;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    StartShake();
        //}

        if (!shake)
        {
            return;
        }

        generalTimer += Time.deltaTime;
        if (generalTimer >= generalTime)
        {
            generalTimer = 0;
            EndShake();
            return;
        }

        RepeatShake();
       
    }

    private void RepeatShake()
    {
        repeatTimer += Time.deltaTime;
        if (repeatTimer >= repeatTime)
        {
            repeatTimer = 0;
            OffsetCamera();
        }
    }

    private void OffsetCamera()
    {
        float offsetX = Random.Range(-offsetValue, offsetValue);
        float offsetY = Random.Range(-offsetValue, offsetValue);

        Vector3 offsetVector = new Vector3(offsetX, offsetY, 0);

        cam.transform.position += offsetVector;
    }

    public void StartShake()
    {
        if (obstacleSpawner.currentMapLevelData == null)
        {
            return;
        }


        shake = true;
        generalTimer = 0;
        repeatTimer = 0;
    }

    public void EndShake()
    {
        shake = false;

        if (obstacleSpawner.currentMapLevelData != null)
        {
            //Vector3 correctPosition = new Vector3(obstacleSpawner.currentMapLevelData.cameraCenterPosition.x, obstacleSpawner.currentMapLevelData.cameraCenterPosition.y, 0);
            cam.transform.position = (Vector3)obstacleSpawner.currentMapLevelData.cameraCenterPosition + new Vector3(0, 0, -1000);

        }
    }


}
