using UnityEngine;

public class HelpMenuScript : MonoBehaviour
{
    public bool helpMenuOpened;
    public GameObject helpMenuObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenCloseHelpMenu();
        }
    }

    private void OpenCloseHelpMenu()
    {
        if (helpMenuOpened)
        {
            helpMenuObject.SetActive(false);
        }
        else
        {
            helpMenuObject.SetActive(true);

        }

        helpMenuOpened = !helpMenuOpened;
    }
}
