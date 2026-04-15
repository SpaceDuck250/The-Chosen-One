using UnityEngine;

public class EnemyCollisionScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            return;
        }

        DoDamage();
    }

    private void DoDamage()
    {
        print("damageDone");
    }
}
