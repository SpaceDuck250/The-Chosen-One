using UnityEngine;
using System;

public class MissileBoomScript : MonoBehaviour
{
    public GameObject boomObj;
    public event Action OnMissileBoom;

    public static event Action OnAnyMissileBoom;
    public static event Action<GameObject> OnMissileAboutToBoom;

    private float boomTimer;
    public float boomTime;

    public float aboutToBoomTime;
    private bool aboutToBoomSetAlready = false;

    public HealthScript healthScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string collisionTag = collision.gameObject.tag;
        if (collisionTag == "Player")
        {
            Boom();
        }

    }

    private void Update()
    {
        boomTimer += Time.deltaTime;

        CheckIfAboutToBoom();
        if (boomTimer >= boomTime)
        {
            Boom();
        }
    }

    private void Boom()
    {
        Instantiate(boomObj, transform.position, Quaternion.identity);
        OnMissileBoom?.Invoke();

        //healthScript.TakeDamage(healthScript.maxHealth);
        Destroy(gameObject);
    }

    private void CheckIfAboutToBoom()
    {
        if (aboutToBoomSetAlready)
        {
            return;
        }

        if (boomTimer >= boomTime - aboutToBoomTime)
        {
            print("about boom");
            OnMissileAboutToBoom?.Invoke(gameObject);
            aboutToBoomSetAlready = true;
        }
    }

}
