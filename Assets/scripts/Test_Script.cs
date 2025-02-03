using UnityEngine;

public class Test_Script : MonoBehaviour
{
    private Animator anim;
    private float speed=0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            speed += 5;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            speed -= 5;
        }
        anim.SetFloat("Direction", speed);
    }
}
