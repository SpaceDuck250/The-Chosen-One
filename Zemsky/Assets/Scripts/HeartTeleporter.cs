using UnityEngine;

public class HeartTeleporter : MonoBehaviour
{

    private void Start()
    {
        ShrineScript.OnMapLevelStart += OnMapLevelStart;
    }

    private void OnDestroy()
    {
        ShrineScript.OnMapLevelStart -= OnMapLevelStart;
    }

    private void OnMapLevelStart(MapLevelData mapLevelData)
    {
        transform.position = mapLevelData.cameraCenterPosition;
    }
}
