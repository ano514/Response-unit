using UnityEngine;

public class DoorControler : MonoBehaviour
{
    public bool open =false;
    private int cislo = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "door")
        {
            Animator animator = other.GetComponentInChildren<Animator>();
            if ( open==true)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (animator.GetBool("Opened"))
                    {
                        animator.SetBool("Opened", false);
                    }
                    if (!animator.GetBool("Opened"))
                    {
                        animator.SetBool("Opened", true);
                    } 
                    Debug.Log(animator.GetBool("Opened"));
                }
            }
            if(Input.GetKeyDown(KeyCode.F) && open==false)
            {
                animator.SetTrigger("Closed");
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (cislo == 3)
                {
                    cislo = 0;
                    open= true;
                    animator.SetBool("Opened", true);

                }
                else
                {
                    cislo++;
                }
                 
            }
        }
    }
}
