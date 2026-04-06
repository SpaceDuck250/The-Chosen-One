using UnityEngine;

public class FallingRockScript : MonoBehaviour
{
    public float waitTime;

    public GameObject fallingRock;

    private void Start()
    {
        Invoke("DoFallingRockAnimation", waitTime);
    }

    private void DoFallingRockAnimation()
    {
        fallingRock.SetActive(true);
    }


}
