using TMPro;
using UnityEngine;

public class BannerScript : MonoBehaviour
{
    public Animator bannerAnimator;
    public TextMeshProUGUI bannerTextComponent;

    public GameObject blackScreen;

    public float blackScreenWaitTime;

    private void Start()
    {
        GameManager.OnGameEnd += OnGameEnd;
    }

    private void OnDestroy()
    {
        GameManager.OnGameEnd -= OnGameEnd;

    }

    private void OnGameEnd(bool gameWon)
    {
        string displayText = gameWon ? "You just got lucky..." : "lol you suck";
        PullDownBanner(displayText);
    }

    private void PullDownBanner(string displayText)
    {
        bannerTextComponent.text = displayText;
        bannerAnimator.SetTrigger("Pulldown");

        blackScreen.SetActive(true);
        Invoke("CloseBlackScreen", blackScreenWaitTime);
    }

    private void CloseBlackScreen()
    {
        blackScreen.SetActive(false);
    }
}
