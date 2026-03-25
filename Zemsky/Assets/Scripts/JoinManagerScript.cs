using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.Utilities;



public class JoinManager : MonoBehaviour
{
    private IDisposable buttonPressListener;

    public InputDevice[] usedDevices = new InputDevice[2];
    public PlayerInput[] playerInputs = new PlayerInput[2];

    public bool newPlayerCanJoin = true;
    public int connectedPlayers = 0;

    public static event Action<GameObject> OnPlayerConnected;

    public static JoinManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        RemoveAllDevices();
    }

    void OnEnable()
    {
        buttonPressListener = InputSystem.onAnyButtonPress.Call(OnAnyButton);
    }

    void OnDisable()
    {
        buttonPressListener?.Dispose();
    }

    private void OnAnyButton(InputControl control)
    {
        if (!newPlayerCanJoin)
        {
            return;
        }

        if (!CheckIfEnoughDevices())
        {
            return;
        }

        var device = control.device;

        if (device is Mouse || device is Keyboard)
        {
            return;
        }
     
        TryAddToUsedDevicesArray(device);
    }

    private void TryAddToUsedDevicesArray(InputDevice newDevice)
    {
        if (CheckIfDeviceAlreadyConnected(newDevice))
        {
            return;
        }

        for (int i = 0; i < usedDevices.Length; i++)
        {
            if (usedDevices[i] == null)
            {
                usedDevices[i] = newDevice;
                AddToConnectedDevicesCount();
                AddDeviceToPlayer(playerInputs[i], usedDevices[i]);

                OnPlayerConnected?.Invoke(playerInputs[i].gameObject);

                return;
            }
        }
    }

    public void ConnectAllPlayers()
    {
        for (int i = 0; i < usedDevices.Length; i++)
        {
            AddDeviceToPlayer(playerInputs[i], usedDevices[i]);
        }
    }

    private void AddDeviceToPlayer(PlayerInput player, InputDevice device)
    {
        InputUser.PerformPairingWithDevice(device, player.user);
    }

    public void RemoveAllDevices()
    {
        if (playerInputs.Length == 0)
        {
            return;
        }

        foreach (var player in playerInputs)
        {
            if (player == null) continue;

            // remove all paired devices
            if (player.devices.Count > 0)
            {
                player.user.UnpairDevices();
            }

            // stop Unity from auto messing with control schemes
            player.neverAutoSwitchControlSchemes = true;
        }
    }

    private bool CheckIfDeviceAlreadyConnected(InputDevice device)
    {
        foreach (var d in usedDevices)
        {
            if (d == device)
                return true;
        }

        return false;
    }

    private void AddToConnectedDevicesCount()
    {
        connectedPlayers++;
        if (connectedPlayers == 2)
        {
            newPlayerCanJoin = false;
        }
    }

    public void AddNewPlayerInputs(PlayerInput[] newPlayerInputs)
    {
        for (int i = 0; i < newPlayerInputs.Length; i++)
        {
            playerInputs[i] = newPlayerInputs[i];
        }
    }

    public bool CheckIfEnoughDevices()
    {
        int totalGamepads = Gamepad.all.Count;
        if (totalGamepads > 0)
        {
            return true;
        }

        return false;
    }

}
