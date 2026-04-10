using System;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public PlayerInputManager inputManager;

    public GameObject bullet;

    public Transform bulletContainer;

    public float fireStrength;

    private bool canShoot = true;
    private bool holdingHeart = false;

    private float rechargeTimer;
    public float rechargeTime;

    private Vector2 roundedShootDirection;

    public static event Action OnAnyShot;

    private void Start()
    {
        bulletContainer = GameObject.FindGameObjectWithTag("BulletContainer").transform;

        inputManager.OnPlayerShoot += OnPlayerShoot;
        SharedHeartPickupScript.OnSharedHeartPickedUp += OnSharedHeartPickup;
        SharedHeartPickupScript.OnSharedHeartReleased += OnRelease;
    }

    private void OnDestroy()
    {
        inputManager.OnPlayerShoot -= OnPlayerShoot;
        SharedHeartPickupScript.OnSharedHeartPickedUp -= OnSharedHeartPickup;
        SharedHeartPickupScript.OnSharedHeartReleased -= OnRelease;

    }

    private void Update()
    {
        if (roundedShootDirection == Vector2.zero || holdingHeart)
        {
            return;
        }

        if (!canShoot)
        {
            RechargeShot();
            return;
        }

        ShootBullet(bullet, roundedShootDirection);
    }

    private void OnPlayerShoot(Vector2 shootDirection)
    {
        roundedShootDirection = CalculationUtilities.RoundShootDirection(shootDirection);
        //print(shootDirection + "mog");
    }

    private void ShootBullet(GameObject bullet, Vector2 direction)
    {
        OnAnyShot?.Invoke();

        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity, bulletContainer);

        BulletScript bulletScript = newBullet.GetComponent<BulletScript>();

        Vector2 shootForce = direction * fireStrength;
        bulletScript.Fire(gameObject, shootForce);
        canShoot = false;

    }

    private void RechargeShot()
    {
        rechargeTimer += Time.deltaTime;
        if (rechargeTimer >= rechargeTime)
        {
            rechargeTimer = 0;
            canShoot = true;
        }
    }
    private void OnSharedHeartPickup(GameObject picker)
    {
        if (picker == gameObject)
        {
            holdingHeart = true;
        }
    }

    private void OnRelease(GameObject releaser)
    {
        if (releaser == gameObject)
        {
            holdingHeart = false;

            rechargeTimer = 0;
            canShoot = false;
        }
    }
}
