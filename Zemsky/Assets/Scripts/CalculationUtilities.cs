using UnityEngine;

public class CalculationUtilities : MonoBehaviour
{
    public static Vector2 RoundShootDirection(Vector2 unroundedShootDirection)
    {
        int x = Mathf.RoundToInt(unroundedShootDirection.x);
        int y = Mathf.RoundToInt(unroundedShootDirection.y);

        Vector2 roundedShootDirection = new Vector2(x, y);
        roundedShootDirection = CheckIfDiagonalAndFix(roundedShootDirection);

        return roundedShootDirection;
    }

    private static Vector2 CheckIfDiagonalAndFix(Vector2 direction)
    {
        float x = direction.x;
        float y = direction.y;

        if (x != 0 && y != 0)
        {
            Vector2 newDirection = new Vector2(x / Mathf.Sqrt(2), y / Mathf.Sqrt(2));
            print(newDirection + "new direction");
            return newDirection;
        }

        return direction;
    }
}
