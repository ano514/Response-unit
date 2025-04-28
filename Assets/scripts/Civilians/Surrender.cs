using UnityEngine;
using UnityEngine.AI;

public class Surrender : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private bool flash = false;
    private float flashdelay = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reference();
    }

    // Update is called once per frame
    void Update()
    {
        if (flash == true)
        {
            flashdelay -= Time.deltaTime;

            if (flashdelay <= 0)
            {
                anim.SetBool("Flash", false);
                flash = false;
                flashdelay = 10f;
                agent.isStopped = false;
            }
        }
    }
    public void Arest()
    {
        if (anim.GetBool("Surender"))
        {
            anim.SetBool("Surender", false);
            anim.SetBool("Arrest", true);
            PointSystem.CivilianArrestAddPoint(1);
        }
    }
    public void Surender()
    {
        agent.Stop();
        anim.SetBool("Surender",true);

    }
    public void Flash()
    {
        agent.Stop();
        anim.SetBool("Flash", true);
        flash = true;
    }
    private void Reference()
    {
        anim=GetComponentInChildren<Animator>();
        agent=GetComponent<NavMeshAgent>();
    }
   
}
