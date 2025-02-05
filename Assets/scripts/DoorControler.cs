using UnityEngine;

public class DoorControler : MonoBehaviour
{
    public bool open =false;
    private int cislo = 0;
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if ( open==true)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (anim.GetBool("Opened"))
                    {
                        anim.SetBool("Opened", false);
                    }
                    if (!anim.GetBool("Opened"))
                    {
                        anim.SetBool("Opened", true);
                    } 
                    Debug.Log(anim.GetBool("Opened"));
                }
            }
            if(Input.GetKeyDown(KeyCode.F) && open==false)
            {
                anim.SetTrigger("Closed");
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (cislo == 3)
                {
                    cislo = 0;
                    open= true;
                    anim.SetBool("Opened", true);

                }
                else
                {
                    cislo++;
                }
                 
            }
        }
    }
}
