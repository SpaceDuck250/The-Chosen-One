using UnityEngine;

public class BoomSubscriber : MonoBehaviour
{
    public MissileBoomScript missileBoomScript;
    public AlertOnDeath alertOnDeathScript;

    private void Start()
    {
        missileBoomScript.OnMissileBoom += OnMissileBoom;
    }

    private void OnDestroy()
    {
        missileBoomScript.OnMissileBoom -= OnMissileBoom;

    }

    private void OnMissileBoom()
    {
        alertOnDeathScript.AlertMobCounter();
    }
}
