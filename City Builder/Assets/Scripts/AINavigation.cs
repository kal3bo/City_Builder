using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    [HideInInspector] public Vector3 targetPosition;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navMeshAgent.destination = targetPosition;

        if (navMeshAgent.remainingDistance <= 0.2f)
        {
            Destroy(gameObject);
        }
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}