using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class SlowTextScript : MonoBehaviour
{
    public List<string> dialogueTexts = new List<string>();

    public int currentDialogueIndex = 0;

    public float waitTimeForLetter;

    public TextMeshProUGUI dialogueTextComponent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayDialogue();
        }
    }

    private void PlayDialogue()
    {
        StopAllCoroutines();
        dialogueTextComponent.text = string.Empty;

        if (currentDialogueIndex >= dialogueTexts.Count)
        {
            SceneManager.LoadScene("SelectMenu");
            return;
        }

        StartCoroutine(WriteTextSlowly(currentDialogueIndex));
        currentDialogueIndex++;

    }

    private IEnumerator WriteTextSlowly(int sentenceIndex)
    {
       

        char[] wordsToBreakdown = dialogueTexts[sentenceIndex].ToCharArray();

        for (int i = 0; i < wordsToBreakdown.Length; i++)
        {
            dialogueTextComponent.text += wordsToBreakdown[i];
            yield return new WaitForSeconds(waitTimeForLetter);
        }



    }
}
