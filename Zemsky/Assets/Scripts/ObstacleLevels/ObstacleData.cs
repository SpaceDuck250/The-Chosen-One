using UnityEngine;
using Edge;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "Scriptable Objects/ObstacleData")]
public class ObstacleData : ScriptableObject
{
    public Vector2 spawnPosition;

    public GameObject obstacleObj;
}
