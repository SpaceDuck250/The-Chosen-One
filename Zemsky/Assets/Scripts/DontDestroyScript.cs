using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
    public static DontDestroyScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);

            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
