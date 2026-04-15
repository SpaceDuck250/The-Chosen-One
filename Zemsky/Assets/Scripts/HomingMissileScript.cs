using UnityEngine;

public class HomingMissileScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public Transform heartTransformTarget;

    public float moveSpeed;

    public float rotateSmoothValue;

    private void Start()
    {
        heartTransformTarget = GameManager.instance.sharedHeart.transform;

    }

    private void MoveForward(float speed)
    {
        rb.linearVelocity = transform.right * speed;
    }

    private void Update()
    {
        RotateTowardsTarget();
        MoveForward(moveSpeed);

    }

    private void RotateTowardsTarget()
    {
        if (heartTransformTarget == null)
        {
            return;
        }

        Vector3 angleVector = (heartTransformTarget.position - transform.position).normalized;

        float turnAngle = Mathf.Atan2(angleVector.y, angleVector.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(0, 0, turnAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, turnAngle), Time.deltaTime * rotateSmoothValue);

    }


}
