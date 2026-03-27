using UnityEngine;
using System;

public class ShrineScript : MonoBehaviour
{
    public event 
    public event Action<MapLevelData> OnMapLevelStart;

    public MapLevelData mapLevelContained;

    public GameObject playersParent;

    public int totalPlayersEntered;

    private void TeleportPlayersToNewMap()
    {
        playersParent.transform.position = mapLevelContained.cameraCenterPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }

    private void CountPlayers(int addAmount)
    {
        totalPlayersEntered += addAmount;
        if (totalPlayersEntered == 2)
        {

        }
    }
}
