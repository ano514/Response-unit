using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private Vector3 lastKnowPos;
    public Animator anim;
    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }
    public Vector3 LastKnowPos { get => lastKnowPos; set => lastKnowPos = value; }
    public string currentState;
    public Path path;
    private GameObject player;
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;
    public BulletSpawnerEnemy sp;
    // Start is called once beffre the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        References();
        stateMachine.Initialise();
        Debug.Log(player);
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
        
    }
    private void References()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        sp = GetComponentInChildren<BulletSpawnerEnemy>();
        anim = GetComponentInChildren<Animator>();
    }
    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if(Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDiregtion = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDiregtion,transform.position);
                if (angleToPlayer >= - fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position+ (Vector3.up * eyeHeight), targetDiregtion);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        Debug.Log(hitInfo.transform.gameObject);
                        if (hitInfo.transform.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }
                }
            }

        }
        return false;
    }
}
