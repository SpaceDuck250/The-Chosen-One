using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public GameObject bulletObj;
    public Transform bulletContainer;

    private float timer;
    public float timeUntilNextShot;

    public int ammo;
    public float shootStrength;
    public Vector2 shootDirection;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeUntilNextShot)
        {
            timer = 0;
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        GameObject newBullet = Instantiate(bulletObj, transform.position, Quaternion.identity, bulletContainer);

        BulletScript bulletScript = newBullet.GetComponent<BulletScript>();
        if (bulletScript != null)
        {
            Vector2 shootForce = shootDirection * shootStrength;
            bulletScript.Fire(gameObject, shootForce);

            ammo--;
            if (ammo == 0)
            {
                Destroy(gameObject);
                return;
            }

        }
    }
}
