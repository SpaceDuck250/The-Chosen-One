using UnityEngine;

public class SharedHeartCollideScript : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public SharedHeartScript heartScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (heartScript.followPlayer)
        {
            boxCollider.isTrigger = true;

            return;
        }

        boxCollider.isTrigger = false;
    }
}
