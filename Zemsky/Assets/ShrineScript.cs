using UnityEngine;
using System;

public class ShrineScript : MonoBehaviour
{
    public event Action<int> OnPlayerEnter;
    public static event Action<MapLevelData> OnMapLevelStart;

    public MapLevelData mapLevelContained;

    public GameObject playersParent;

    public int totalPlayersEntered;

    private void TeleportPlayersToNewMap()
    {
        playersParent.transform.position = mapLevelContained.cameraCenterPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.instance.CheckIfPlayer(collision.gameObject))
        {
            if (playersParent == null)
            {
                playersParent = collision.gameObject.transform.parent.gameObject;
            }

            CountPlayers(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GameManager.instance.CheckIfPlayer(collision.gameObject))
        {
            if (playersParent == null)
            {
                playersParent = collision.gameObject.transform.parent.gameObject;
            }

            CountPlayers(-1);
        }
    }

    private void CountPlayers(int addAmount)
    {
        totalPlayersEntered += addAmount;
        OnPlayerEnter?.Invoke(totalPlayersEntered);

        if (totalPlayersEntered == 2)
        {
            OnMapLevelStart?.Invoke(mapLevelContained);
            TeleportPlayersToNewMap();
        }
    }
}
