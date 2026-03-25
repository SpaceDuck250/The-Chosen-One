using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnerScript : MonoBehaviour
{
    public PlayerInput[] playerInputArray = new PlayerInput[2];
    public JoinManager joinManager;

    private void Start()
    {
        joinManager = JoinManager.instance;
        if (joinManager == null)
        {
            return;
        }

        SetupPlayers();
        SpawnInPlayers();

    }

    private void SetupPlayers()
    {
        joinManager.AddNewPlayerInputs(playerInputArray);
    }

    private void SpawnInPlayers()
    {
        joinManager.RemoveAllDevices();
        joinManager.ConnectAllPlayers();
    }
}
