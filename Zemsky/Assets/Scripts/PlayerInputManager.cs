using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInputManager : MonoBehaviour
{
    public event Action<Vector2> OnPlayerMove;
    public event Action<Vector2> OnPlayerShoot;
    public event Action OnTryPickupHeart;

    private void OnMove(InputValue input)
    {
        Vector3 moveInput = input.Get<Vector2>();
 
        print(moveInput);

        OnPlayerMove?.Invoke(moveInput);
    }

    private void OnShoot(InputValue input)
    {
        Vector3 shootDirection = input.Get<Vector2>();

        print(shootDirection);

        OnPlayerShoot?.Invoke(shootDirection);
    }

    private void OnHeartPickup(InputValue input)
    {
        if (input == null)
        {
            return;
        }

        OnTryPickupHeart?.Invoke();
    }

}
