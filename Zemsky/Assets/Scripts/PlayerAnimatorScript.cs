using UnityEngine;

public class PlayerAnimatorScript : MonoBehaviour
{
    public Animator animator;

    public void PlayMoveAnimation(float speed)
    {
        animator.SetFloat("speed", speed);
    }
}
