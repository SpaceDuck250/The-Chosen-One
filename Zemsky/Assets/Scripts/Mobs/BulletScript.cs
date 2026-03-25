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
        rb.AddForce(shootForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == tagToIgnore || other.gameObject == shooter)
        {
            return;
        }

        HealthScript healthScript = other.gameObject.GetComponent<HealthScript>();
        if (healthScript != null)
        {
            ApplyDamage(healthScript);
        }

        Destroy(gameObject);
    }

    private void ApplyDamage(HealthScript healthScript)
    {
        healthScript.TakeDamage(damage);
    }
}
