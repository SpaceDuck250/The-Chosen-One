using UnityEngine;

public class ZombieChaseScript : MonoBehaviour
{
    public Transform target;

    public float smoothValue;

    private void Start()
    {
        target = SharedHeartScript.instance.gameObject.transform;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * smoothValue);
    }
}
