using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject camera;
    public GameObject sharedHeart;
    public GameObject sharedPlayer;

    public MapLevelData mainAreaLevelSelectorArea;

    public static event Action<bool> OnGameEnd;

    public float camOffset;

    public HealthScript playerHealthScript;

    private void Start()
    {
        ShrineScript.OnMapLevelStart += OnMapLevelStart;
        OnGameEnd += OnGameEndFunction;

        playerHealthScript.OnDeath += OnDeath;
    }

    private void OnDestroy()
    {
        ShrineScript.OnMapLevelStart -= OnMapLevelStart;
        OnGameEnd -= OnGameEndFunction;

        playerHealthScript.OnDeath -= OnDeath;
    }

    private void OnMapLevelStart(MapLevelData mapLevelData)
    {
        Vector2 newMapPosition = mapLevelData.cameraCenterPosition;

        Transport(camera, newMapPosition, camOffset);
        Transport(sharedHeart, newMapPosition);

        // Player transport handled by the shrine script already for some reason or another because im clown
    }

    private void OnDeath(HealthInfo healthInfo)
    {
        OnGameEnd?.Invoke(false);
    }

    public void OnGameEndFunction(bool gameWon)
    {
        TransportBackToMainArea();
    }

    public void Transport(GameObject objToTransport, Vector2 newPosition, float zOffset = 0)
    {
        Vector3 zOffsetVector = new Vector3(0, 0, zOffset);

        objToTransport.transform.position = (Vector3)newPosition + zOffsetVector;
    }

    public void TransportBackToMainArea()
    {
        Vector2 mainAreaPosition = mainAreaLevelSelectorArea.cameraCenterPosition;

        Transport(camera, mainAreaPosition, camOffset);
        //Transport(sharedHeart, mainAreaPosition);
        Transport(sharedPlayer, mainAreaPosition);
    }
}
