using UnityEngine;
using System;

public class SharedHeartPickupScript : MonoBehaviour
{
    public static event Action<GameObject> OnSharedHeartPickedUp;
    public static Action<GameObject> OnSharedHeartReleased;

    public PlayerInputManager inputManager;

    public GameObject sharedHeart;
    public SharedHeartScript sharedHeartScript;

    public bool holdingHeart = false;

    public float pickupRange;

    private void Start()
    {
        inputManager.OnTryPickupHeart += OnTryPickupHeartOrRelease;
        GameManager.OnGameEnd += OnGameEnd;
    }

    private void OnDestroy()
    {
        inputManager.OnTryPickupHeart -= OnTryPickupHeartOrRelease;
        GameManager.OnGameEnd -= OnGameEnd;

    }

    private void OnTryPickupHeartOrRelease()
    {
        if (TryReleaseHeart())
        {
            return;
        }

        TryHoldingHeart(); 
    }

    private bool TryReleaseHeart()
    {
        if (holdingHeart)
        {
            print("release");
            holdingHeart = false;
            OnSharedHeartReleased?.Invoke(gameObject);

            return true;
        }

        return false;
    }

    private void TryHoldingHeart()
    {
        if (CheckIfWithinRange() && !sharedHeartScript.followPlayer)
        {
            holdingHeart = true;
            PickupHeart();
        }
    }

    private bool CheckIfWithinRange()
    {
        float distance = Vector2.Distance(transform.position, sharedHeart.transform.position);
        if (distance <= pickupRange)
        {
            return true;
        }

        return false;
    }

    private void PickupHeart()
    {
        //sharedHeart.transform.parent = transform;
        //sharedHeart.transform.localPosition = Vector2.zero;
        sharedHeart.transform.position = transform.position;

        OnSharedHeartPickedUp?.Invoke(gameObject);
    }

    private void OnGameEnd(bool gameWon)
    {
        TryReleaseHeart();
    }
}

