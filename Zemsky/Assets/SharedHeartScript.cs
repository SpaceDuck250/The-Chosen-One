using UnityEngine;
using UnityEngine.InputSystem;

public class SharedHeartScript : MonoBehaviour
{
    public Transform playerToFollow;

    public bool followPlayer = false;

    public BoxCollider2D boxCollider;

    public Rigidbody2D rb;

    public PlayerInputManager inputManager;

    public float shootStrenght;

    public Vector2 shootDirection;

    public static SharedHeartScript instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SharedHeartPickupScript.OnSharedHeartPickedUp += OnSharedHeartPickup;
        SharedHeartPickupScript.OnSharedHeartReleased += OnRelease;
    }

    private void OnDestroy()
    {
        SharedHeartPickupScript.OnSharedHeartPickedUp -= OnSharedHeartPickup;
        SharedHeartPickupScript.OnSharedHeartReleased -= OnRelease;
    }

    private void OnSharedHeartPickup(GameObject playerObj)
    {
        FollowPlayer(playerObj.transform);
    }
    private void OnRelease(GameObject obj)
    {
        print("heart release");
        FollowNobody();
        //rb.AddForce();
    }

    private void Update()
    {
        if (!followPlayer || transform == null || playerToFollow == null)
        {
            return;
        }

        transform.position = playerToFollow.position;
    }

    public void FollowPlayer(Transform player)
    {
        inputManager = player.gameObject.GetComponent<PlayerInputManager>();
        inputManager.OnPlayerShoot += OnPlayerShoot;


        boxCollider.isTrigger = true;

        playerToFollow = player;
        followPlayer = true;
    }

    public void FollowNobody()
    {
        if (!followPlayer)
        {
            return;
        }

        inputManager.OnPlayerShoot -= OnPlayerShoot;

        //boxCollider.isTrigger = false;


        followPlayer = false;

        //SharedHeartPickupScript.OnSharedHeartReleased?.Invoke(gameObject);
        
        print(followPlayer);
    }

    public void OnPlayerShoot(Vector2 input)
    {
        shootDirection = CalculationUtilities.RoundShootDirection(input);
        //shootDirection = input;
        if (shootDirection == Vector2.zero)
        {
            return;
        }

        if (!followPlayer)
        {
            return;
        }

        //FollowNobody();
        SharedHeartPickupScript.OnSharedHeartReleased?.Invoke(inputManager.gameObject);



        //Vector2 shootDirection = CalculationUtilities.RoundShootDirection(input);
        Vector2 shootForce = shootDirection * shootStrenght;
        rb.AddForce(shootForce, ForceMode2D.Impulse);

        Invoke("SetBackToNonTrigger", 0.1f);

    }

    private void SetBackToNonTrigger()
    {
        boxCollider.isTrigger = false;

    }

}
