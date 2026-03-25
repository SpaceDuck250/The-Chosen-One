using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public string tagToIgnore;
    public float damage;

    public GameObject shooter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == tagToIgnore || other.gameObject == shooter)
        {
            return;
        }

        HealthScript healthScript = other.gameObject.GetComponent<HealthScript>();
        ApplyDamage(healthScript);

        Destroy(gameObject);
    }

    private void ApplyDamage(HealthScript healthScript)
    {
        healthScript.TakeDamage(damage);
    }
}
