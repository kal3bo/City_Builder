using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    public Vector3 target;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navMeshAgent.destination = target;
        if (navMeshAgent.remainingDistance <= 0.2f)
        {
            Destroy(gameObject);
        }
    }

    public void SetNewTarget(Vector3 target)
    {
        this.target = target;
    }
}