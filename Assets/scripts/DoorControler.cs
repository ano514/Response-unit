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
            if (Input.GetKeyDown(KeyCode.F) && open==true)
            {
                animator.SetTrigger("OpenClose");
            }
            else
            {
                animator.SetTrigger("Closed");
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (cislo == 3)
                {
                    animator.SetTrigger("Bruce");
                    cislo = 0;
                    open= true;
                }
                else
                {
                    cislo++;
                }
                 
            }
        }
    }
}
