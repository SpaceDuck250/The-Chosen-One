using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class CharMenuInputManager : MonoBehaviour
{
    public static event Action<GameObject> OnReadyPressed;
    private bool canPressReady = true;

    private void Start()
    {
        JoinManager.OnPlayerConnected += OnPlayerConnected;
    }

    private void OnDestroy()
    {
        JoinManager.OnPlayerConnected -= OnPlayerConnected;

    }

    private void OnPlayerConnected(GameObject player)
    {
        if (player != gameObject)
        {
            return;
        }
         
    }

    private void OnReady(InputValue input)
    {
        if (!canPressReady)
        {
            return;
        }

        if (input == null)
        {
            return;
        }

        OnReadyPressed?.Invoke(gameObject);
        canPressReady = false;
    }
}
