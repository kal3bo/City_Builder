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
        // Following the target even though this can change:
        navMeshAgent.destination = targetPosition;

        // Destroting the character once it arrives:
        if (navMeshAgent.remainingDistance <= 0.2f)
        {
            Destroy(gameObject);
        }
    }

    // Setting the target from other scripts:
    public void SetTargetPosition(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}