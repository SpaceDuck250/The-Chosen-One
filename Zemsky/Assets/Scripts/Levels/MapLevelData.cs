using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MapLevelData", menuName = "Scriptable Objects/MapLevelData")]
public class MapLevelData : ScriptableObject
{
    public Vector2 cameraCenterPosition;

    public string mapName;

    public List<ObstacleData> obstacleList;
}
