
using System.IO;
using UnityEngine;
using UnityEngine.AI;
public class ShootingMovement : MonoBehaviour
{
    private StateMachineBehaviour stateMachine;
    private NavMeshAgent agent;

    public NavMeshAgent Agent { get => agent; }
    [SerializeField]
    private string currentState;
    private GameObject player;
    public float sightDistance = 20f;
    public float fieldOfView = 85f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void RaycastHit()
    {
        
    }
    private void References()
    {
        stateMachine= GetComponent<StateMachineBehaviour>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
           
    }
}
