using UnityEngine;

public class FallingRockSpawnerScript : MonoBehaviour
{
    public GameObject fallingRock;

    private float repeatTimer;
    public float waitTime;

    public float offsetRange;

    public Transform container;

    private void Start()
    {
        container = GameObject.FindGameObjectWithTag("BulletContainer").transform;
    }

    private void Update()
    {
        repeatTimer += Time.deltaTime;
        if (repeatTimer >= waitTime)
        {
            repeatTimer = 0;
            SpawnRockAtRandomLocation();
        }
    }

    public void SpawnRockAtRandomLocation()
    {
        float xOffset = Random.Range(-offsetRange, offsetRange);
        float yOffset = Random.Range(-offsetRange, offsetRange);

        Vector2 spawnPos = new Vector2(xOffset, yOffset);

        Instantiate(fallingRock, spawnPos, Quaternion.identity, container);

    }
}
