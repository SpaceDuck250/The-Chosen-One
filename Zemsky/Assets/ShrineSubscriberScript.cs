using UnityEngine;

public class ShrineSubscriberScript : MonoBehaviour
{
    public ShrineScript shrineScript;

    public bool playerIn = false;

    public Sprite completedShrineSprite;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        ShrineScript.OnMapLevelStart += OnLevelStart;
        GameManager.OnGameEnd += OnGameEnd;
    }

    private void OnDestroy()
    {
        ShrineScript.OnMapLevelStart -= OnLevelStart;
        GameManager.OnGameEnd -= OnGameEnd;

    }

    private void OnLevelStart(MapLevelData mapLevelData)
    {
        if (shrineScript.mapLevelContained != mapLevelData)
        {
            return;
        }

        playerIn = true;
    }

    private void OnGameEnd(bool gameWon)
    {
        if (playerIn && gameWon)
        {
            ChangeShrineSprite();
        }

        playerIn = false;
    }

    private void ChangeShrineSprite()
    {
        spriteRenderer.sprite = completedShrineSprite;
    }

}
