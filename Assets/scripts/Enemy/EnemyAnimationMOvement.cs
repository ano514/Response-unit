using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationMOvement : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    void Start()
    {
        References();
    }

    void Update()
    {
        
        if (agent.isStopped)
        {
            animator.SetBool("GO?", false);
        }
        else
        {
            animator.SetBool("GO?", true);
        }
    }
    void References()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
}
