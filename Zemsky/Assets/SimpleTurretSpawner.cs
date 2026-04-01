using UnityEngine;
using Edge;

public class SimpleTurretSpawner : MonoBehaviour
{
    public GameObject turretObj;
    public Transform container;
    public Transform bulletContainer;

    public int amountToSpawn;
    public float separationBetweenTurrets;
    public EdgeType edgeLineAxis;
    public Polarity polarity;

    public EdgePositionGetter edgeGetterScript;

    private void Start()
    {
        container = GameObject.FindGameObjectWithTag("Container").transform;
        bulletContainer = GameObject.FindGameObjectWithTag("BulletContainer").transform;

        float spawnDelay = 0.1f;
        Invoke("SpawnAllTurrets", spawnDelay);
    }

    public void SpawnAllTurrets()
    {
        if (CheckIfOdd(amountToSpawn))
        {
            Vector2 centerPosition = edgeGetterScript.GetPositionOnEdgeLine(edgeLineAxis, 0, polarity);
            SpawnTurret(centerPosition);
        }

        int amountToSpawnOnOneSide = CheckIfOdd(amountToSpawn) ? (amountToSpawn-1) / 2 : amountToSpawn / 2;

        float separation = separationBetweenTurrets;

        int posOffsetSide = 1;
        SpawnTurretsOnOneSide(amountToSpawnOnOneSide, separation, polarity, posOffsetSide);

        int negOffsetSide = -1;
        SpawnTurretsOnOneSide(amountToSpawnOnOneSide, separation, polarity, negOffsetSide);
    }

    private void SpawnTurret(Vector2 spawnPosition)
    {
        GameObject newTurret = Instantiate(turretObj, spawnPosition, Quaternion.identity, container);

        TurretScript turretScript = newTurret.GetComponent<TurretScript>();
        turretScript.bulletContainer = bulletContainer;
        turretScript.shootDirection = CalculateCorrectShootDirection();
    }

    private bool CheckIfOdd(int num)
    {
        if (num % 2 == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void SpawnTurretsOnOneSide(int amountToSpawnOnOneSide, float separation, Polarity polarity, int offsetSide)
    {

        for (int i = 1; i < amountToSpawnOnOneSide + 1; i++)
        {
            float offset = i * separation * offsetSide;
            Vector2 spawnPosition = edgeGetterScript.GetPositionOnEdgeLine(edgeLineAxis, offset, polarity);
            SpawnTurret(spawnPosition);
        }
    }

    private Vector2 CalculateCorrectShootDirection()
    {
        Vector2 shootDirection = Vector2.zero;

        if (edgeLineAxis == EdgeType.y)
        {
            shootDirection = polarity == Polarity.positive ? Vector2.down : Vector2.up;
        }

        if (edgeLineAxis == EdgeType.x)
        {
            shootDirection = polarity == Polarity.positive ? Vector2.left : Vector2.right;
        }

        return shootDirection;

    }


}
