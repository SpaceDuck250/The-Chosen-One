using UnityEngine;
using System.Collections;
using TMPro;

public class ReadyTextScript : MonoBehaviour
{
    public string[] readyWordsList = new string[3];

    public TextMeshProUGUI readyTextComponent;

    public float timeBetweenWords;

    private void Start()
    {
        LocationTextScript.OnLocationTextShown += OnLocationTextShown;
    }

    private void OnDestroy()
    {
        LocationTextScript.OnLocationTextShown -= OnLocationTextShown;

    }

    private void OnLocationTextShown()
    {
        //StopAllCoroutines();

        StartCoroutine(ShowReadyWords());
    }

    private IEnumerator ShowReadyWords()
    {
        for (int i = 0; i < readyWordsList.Length; i++)
        {
            string readyWord = readyWordsList[i];
            readyTextComponent.text = readyWord;

            yield return new WaitForSeconds(timeBetweenWords);
        }

        readyTextComponent.text = string.Empty;
    }

}
