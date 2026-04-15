using UnityEngine;

public class LogScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float rollSpeed;

    public Vector2 moveDirection;

    public float damage;

    private void Start()
    {
        Roll();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthScript healthScript = collision.gameObject.GetComponent<HealthScript>();
        if (healthScript != null)
        {
            healthScript.TakeDamage(damage);
        }
    }

    private void Roll()
    {
        rb.linearVelocity = moveDirection.normalized * rollSpeed;
    }

}
