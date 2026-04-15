using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject camera;
    public GameObject sharedHeart;
    public GameObject sharedPlayer;

    public MapLevelData mainAreaLevelSelectorArea;

    public static Action<bool> OnGameEnd;

    public float camOffset;

    public HealthScript playerHealthScript;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

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

        Vector3 playerSpawnOffset = new Vector3(0, 1, 0);
        SetPlayersLocalPosition(playerSpawnOffset);
    }

    public void TransportBackToMainArea()
    {
        Vector2 mainAreaPosition = mainAreaLevelSelectorArea.cameraCenterPosition;

        Transport(camera, mainAreaPosition, camOffset);
        //Transport(sharedHeart, mainAreaPosition);
        Transport(sharedPlayer, mainAreaPosition);

        Vector3 playerSpawnOffset = new Vector3(-10, 0, 0);
        SetPlayersLocalPosition(playerSpawnOffset);
    }

    private void SetPlayersLocalPosition(Vector3 offset)
    {
        foreach (Transform child in sharedPlayer.transform)
        {
            child.transform.localPosition = offset;
        }
    }

    public bool CheckIfPlayer(GameObject objToCheck)
    {
        foreach (Transform player in sharedPlayer.transform)
        {
            if (objToCheck == player.gameObject)
            {
                return true;
            }
        }

        return false;
    }
}
