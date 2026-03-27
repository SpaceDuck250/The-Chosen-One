using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public PlayerInputManager inputManager;

    public float smoothValue;
    public float moveSpeed;
    // maybe do slower speed for diagonal

    public Rigidbody2D rb;

    private Vector2 refVelocity;

    public Vector2 moveInput;

    public PlayerAnimatorScript playerAnimatorScript;

    private void Start()
    {
        inputManager.OnPlayerMove += OnPlayerMove;
    }

    private void OnDestroy()
    {
        inputManager.OnPlayerMove -= OnPlayerMove;
    }

    private void OnPlayerMove(Vector2 moveInput)
    {
        this.moveInput = moveInput;
    }

    private void FixedUpdate()
    {
        Move(moveInput);
    }

    private void Move(Vector2 moveInput)
    {
        Vector2 targetVelocity = moveInput * moveSpeed;

        rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetVelocity, ref refVelocity, Time.fixedDeltaTime * smoothValue);

        // Make cleaner later
        float playerSpeed = moveInput.magnitude;
        playerAnimatorScript.PlayMoveAnimation(playerSpeed);
    }
}
