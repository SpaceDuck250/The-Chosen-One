using UnityEngine;

public class EnemyHitScript : MonoBehaviour
{
    public float damagePerWaitTime;
    public float waitTime;

    private float timer;

    private bool canHit;

    public HealthScript playerHeartHealthScript;
    public GameObject sharedHeartObj;

    private void Start()
    {
        playerHeartHealthScript = GameManager.instance.playerHealthScript;
        sharedHeartObj = GameManager.instance.sharedHeart;
    }

    private void Update()
    {
        TryHitRepeatedly();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" || collision.gameObject != sharedHeartObj)
        {
            return;
        }

        TurnOnHitting(true);


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player" || collision.gameObject != sharedHeartObj)
        {
            return;
        }

        TurnOnHitting(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TurnOnHitting(false);
    }

    private void TurnOnHitting(bool value)
    {
        canHit = value;
    }

    private void TryHitRepeatedly()
    {
        if (!canHit)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            timer = 0;

            DoDamage(damagePerWaitTime, playerHeartHealthScript);
        }
    }

    private void DoDamage(float amount, HealthScript healthScript)
    {
        healthScript.TakeDamage(amount);
    }
}
