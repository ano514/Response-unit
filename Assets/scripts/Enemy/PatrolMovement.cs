using UnityEngine;
using UnityEngine.AI;

public class PatrolMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range; 
    public Transform centrePoint;
    public bool Patrol;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Patrol = true;
    }


    void Update()
    {
        if (Patrol)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, range, out point))
                {
                    agent.SetDestination(point);
                }
            }
        }

    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        { 
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

}
