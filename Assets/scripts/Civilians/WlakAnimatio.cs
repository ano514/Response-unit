using GLTFast.Schema;
using UnityEngine;
using UnityEngine.AI;

public class WlakAnimatio : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        References();
    }

    // Update is called once per frame
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
