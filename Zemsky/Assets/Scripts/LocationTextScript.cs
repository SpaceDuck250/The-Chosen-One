using TMPro;
using UnityEngine;
using System.Collections;
using System;

public class LocationTextScript : MonoBehaviour
{
    public TextMeshProUGUI locationTextComponent;
    public float displayTime;

    public static event System.Action OnLocationTextShown;

    public Animator fadeAnimator;

    private void Start()
    {
        ShrineScript.OnMapLevelStart += OnLocationChange;
    }

    private void OnDestroy()
    {
        ShrineScript.OnMapLevelStart -= OnLocationChange;
    }

    private void OnLocationChange(MapLevelData mapLevelData)
    {
        //StopAllCoroutines();

        string newLocationName = mapLevelData.mapName;
        StartCoroutine(ShowLocationWithText(newLocationName));
    }

    private IEnumerator ShowLocationWithText(string locationName)
    {
        locationTextComponent.text = locationName;
        fadeAnimator.SetTrigger("fade");

        yield return new WaitForSeconds(displayTime);
        locationTextComponent.text = string.Empty;

        OnLocationTextShown?.Invoke();
    }
}
