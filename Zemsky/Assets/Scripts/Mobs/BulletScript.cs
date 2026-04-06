using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public string tagToIgnore;
    public float damage;

    public GameObject shooter;
    public Rigidbody2D rb;

    public void Fire(GameObject shooter, Vector2 shootForce)
    {
        this.shooter = shooter;

        float turnAngle = OrientScript.CalculateTurnAngle(shootForce);
        transform.rotation = Quaternion.Euler(0, 0, turnAngle);

        rb.AddForce(shootForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject + "-Arrow");
        if (other.tag == tagToIgnore || other.gameObject == shooter || other.gameObject == gameObject)
        {
            print("ignored");
            return;
        }

        HealthScript healthScript = other.gameObject.GetComponent<HealthScript>();
        if (healthScript != null)
        {
            print("didnt");

            ApplyDamage(healthScript);

        }

        Destroy(gameObject);


    }

    private void ApplyDamage(HealthScript healthScript)
    {
        healthScript.TakeDamage(damage);
    }
}
