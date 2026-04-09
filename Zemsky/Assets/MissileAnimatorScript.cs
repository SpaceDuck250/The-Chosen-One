using UnityEngine;

public class MissileAnimatorScript : MonoBehaviour
{
    public Animator missileAnimator;

    private void Start()
    {
        MissileBoomScript.OnMissileAboutToBoom += OnMissileAboutToBoom;
    }

    private void OnDestroy()
    {
        MissileBoomScript.OnMissileAboutToBoom -= OnMissileAboutToBoom;

    }

    private void OnMissileAboutToBoom(GameObject boomer)
    {
        if (boomer != gameObject)
        {
            return;
        }

        missileAnimator.SetTrigger("Color");
    }
}
