using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public float destroyTime;

    private void Start()
    {
        Invoke("DestroySelf", destroyTime);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
