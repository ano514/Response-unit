using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Granade : MonoBehaviour
{
    public float delay = 3f;
    public float fieldOfView = 360f;
    public float sightDistance = 10f;
    public Volume volume;
    public CanvasGroup AlphaController;
    public AudioSource bang;
    [SerializeField]private GameObject player;
    [SerializeField] private GameObject[] enemy;
    private bool on = false;
    float countdown;
    private bool isExplode = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        References();
        countdown = delay;

    }

    // Update is called once per frame
    void Update()
    {

        CanSeePlayerEnemy();

        
    }
    private void References()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }
    void FlashBanged()
    {
        volume.weight=1.0f;
        on=true;
        bang.Play();
        AlphaController.alpha = 1;
    }

    public void CanSeePlayerEnemy()
    {
        if (player != null || enemy != null)
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                if (Vector3.Distance(transform.position, player.transform.position) < sightDistance || Vector3.Distance(transform.position, enemy[i].transform.position) < sightDistance)
                {
                    Vector3 targetDiregtionPlayer = player.transform.position - transform.position;
                    Vector3 targetDiregtionEnemy = enemy[i].transform.position - transform.position;

                    Ray rayPlayer = new Ray(transform.position, targetDiregtionPlayer);
                    Ray rayEnemy = new Ray(transform.position, targetDiregtionEnemy);
                    RaycastHit hitInfoPlayer = new RaycastHit();
                    RaycastHit hitInfoEnemy = new RaycastHit();

                    if (Physics.Raycast(rayPlayer, out hitInfoPlayer, sightDistance))
                    {
                        
                            Debug.Log("mam player");
                            Debug.DrawRay(rayPlayer.origin, rayPlayer.direction * sightDistance);

                        
                    }
                    if (Physics.Raycast(rayEnemy, out hitInfoEnemy, sightDistance))
                    {

                        
                            Debug.Log("mam enemy");
                            Debug.DrawRay(rayEnemy.origin, rayEnemy.direction * sightDistance);

                        
                    }
                }
            }
        }

        }
    }

