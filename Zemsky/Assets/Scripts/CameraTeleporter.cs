using UnityEngine;

public class CameraTeleporter : MonoBehaviour
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

        Vector3 zOffset = new Vector3(0, 0, -1000);
        transform.position += zOffset;
    }
}
