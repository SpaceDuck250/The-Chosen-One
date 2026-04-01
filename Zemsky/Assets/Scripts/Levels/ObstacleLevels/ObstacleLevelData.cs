using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ObstacleLevelData", menuName = "Scriptable Objects/ObstacleLevelData")]
public class ObstacleLevelData : ScriptableObject
{
    public List<ObstacleData> obstaclesList;
}
