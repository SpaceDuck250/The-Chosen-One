using UnityEngine;

public class OrientScript : MonoBehaviour
{
    public static float CalculateTurnAngle(Vector2 moveDirection)
    {
        float turnAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        return turnAngle;
    }
}
