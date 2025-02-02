using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent; }
    public string currentState;
    public Path path;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        References();
        stateMachine.Initialise();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void References()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
    }
}
