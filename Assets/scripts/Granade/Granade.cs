using UnityEngine;
using UnityEngine.Rendering;

public class Granade : MonoBehaviour
{
    public float delay = 3f;
    public float fieldOfView = 360f;
    public float sightDistance = 30f;
    public Volume volume;
    public CanvasGroup AlphaController;
    public AudioSource bang;
    private Terorist ter;
    private Surrender sur;
    [SerializeField]private GameObject player;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject[] civil;
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
        delay -= Time.deltaTime;
        if (delay<=0&&!isExplode)
        {



            CanSeePlayerEnemy();
            
            isExplode = true;
        }
        if (on == true)
        {
            Time.timeScale = 0.1f;
            AlphaController.alpha = AlphaController.alpha - Time.deltaTime * 2;
            volume.weight = volume.weight - Time.deltaTime * 2;
            if (AlphaController.alpha <= 0)
            {
                volume.weight = 0;
                AlphaController.alpha = 0;
                Time.timeScale = 1;
                on = false;
            }
        }
        if (!on&&isExplode)
        {
            Destroy(gameObject);
        }


    }
    private void References()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        civil = GameObject.FindGameObjectsWithTag("Civil");
        bang= GetComponentInChildren<AudioSource>();
        AlphaController = GetComponentInChildren<CanvasGroup>();
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
                for (int j = 0; j < civil.Length; j++)
                {
                    if (Vector3.Distance(transform.position, player.transform.position) < sightDistance || Vector3.Distance(transform.position, enemy[i].transform.position) < sightDistance)
                    {
                        Vector3 targetDiregtionPlayer = player.transform.position - transform.position;
                        Vector3 targetDiregtionEnemy = enemy[i].transform.position - transform.position;
                        Vector3 targetDiregtionCivil = civil[j].transform.position - transform.position;

                        Ray rayPlayer = new Ray(transform.position, targetDiregtionPlayer);
                        Ray rayEnemy = new Ray(transform.position, targetDiregtionEnemy);
                        Ray rayCivil = new Ray(transform.position, targetDiregtionCivil);
                        RaycastHit hitInfoPlayer = new RaycastHit();
                        RaycastHit hitInfoEnemy = new RaycastHit();
                        RaycastHit hitInfoCivil = new RaycastHit();

                        if (Physics.Raycast(rayPlayer, out hitInfoPlayer, sightDistance))
                        {

                            if (hitInfoPlayer.transform.gameObject == player)
                            {
                                Debug.DrawRay(rayPlayer.origin, rayPlayer.direction * sightDistance);
                                FlashBanged();
                            }
                            Debug.DrawRay(rayPlayer.origin, rayPlayer.direction * sightDistance);

                        }
                        if (Physics.Raycast(rayEnemy, out hitInfoEnemy, sightDistance))
                        {
                            if (hitInfoEnemy.transform.gameObject == enemy[i])
                            {
                                Debug.DrawRay(rayEnemy.origin, rayEnemy.direction * sightDistance);
                                ter = enemy[i].GetComponent<Terorist>();
                                ter.Flash();


                            }
                            Debug.DrawRay(rayEnemy.origin, rayEnemy.direction * sightDistance);

                        }
                        if (Physics.Raycast(rayCivil, out hitInfoCivil, sightDistance))
                        {
                            if (hitInfoEnemy.transform.gameObject == enemy[i])
                            {
                                Debug.DrawRay(rayCivil.origin, rayCivil.direction * sightDistance);
                                sur = civil[i].GetComponent<Surrender>();
                                sur.Flash();
                            }
                            Debug.DrawRay(rayCivil.origin, rayCivil.direction * sightDistance);
                            Debug.Log(hitInfoEnemy.transform.gameObject);

                        }


                    }
                }
            }
        }

        }
    }

