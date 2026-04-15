using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveScript : MonoBehaviour
{
    public Transform heartTargetTransform;
    public NavMeshAgent agent;

    private void Start()
    {
        heartTargetTransform = GameManager.instance.sharedHeart.transform;
        agent.updateRotation = false;
        agent.updateUpAxis = false; 

    }

    private void Update()
    {
        agent.SetDestination(heartTargetTransform.position);
    }




}
