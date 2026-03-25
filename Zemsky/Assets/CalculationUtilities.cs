using UnityEngine;

public class CalculationUtilities : MonoBehaviour
{
    public static Vector2 RoundShootDirection(Vector2 unroundedShootDirection)
    {
        int x = Mathf.RoundToInt(unroundedShootDirection.x);
        int y = Mathf.RoundToInt(unroundedShootDirection.y);

        Vector2 roundedShootDirection = new Vector2(x, y);
        return roundedShootDirection;
    }
}
