using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharMenuUIScript : MonoBehaviour
{
    public TextMeshProUGUI connectedTextComponent;
    public TextMeshProUGUI readyTextComponent;

    public Sprite monkSprite;
    public Image monkImageComponent;

    private void Start()
    {
        JoinManager.OnPlayerConnected += OnPlayerConnected;
        CharMenuInputManager.OnReadyPressed += OnReadyPressed;
    }

    private void OnDestroy()
    {
        JoinManager.OnPlayerConnected -= OnPlayerConnected;
        CharMenuInputManager.OnReadyPressed -= OnReadyPressed;

    }

    private void OnReadyPressed(GameObject presser)
    {
        if (presser != gameObject)
        {
            return;
        }

        SetTextComponentTextTo(readyTextComponent, "ready", Color.white);

    }

    private void OnPlayerConnected(GameObject connectedObject)
    {
        if (connectedObject != gameObject)
        {
            return;
        }

        SetTextComponentTextTo(connectedTextComponent, "connected", Color.green);

        ShowMonkImage();
    }

    private void SetTextComponentTextTo(TextMeshProUGUI textComponent, string newText, Color textColor)
    {
        textComponent.text = newText;
        if (textColor != null)
        {
            textComponent.color = textColor; 
        }
    }

    private void ShowMonkImage()
    {
        monkImageComponent.sprite = monkSprite;
        monkImageComponent.gameObject.SetActive(true);
    }
}
