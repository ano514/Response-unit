using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    void Start()
    {
        Animator animator = GetComponent<Animator>();

    }

    void Update()
    {
        bool fowardPressed = Input.GetKey("w");
        bool backPressed = Input.GetKey("s");
        bool rightPressed = Input.GetKey("d");
        bool leftPressed = Input.GetKey("a");
        bool foward = false;
        bool back = false;
        bool right = false;
        bool left = false;
        if (!foward && fowardPressed)
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
            foward = true;
        }
        if (foward && !fowardPressed)
        {
            foward=false;
        }

        if(!back && backPressed)
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
            back = true;
        }
        if(back && !backPressed)
        {
            back = false;
        }
        if (!left && leftPressed)
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed * 2.5f;
            left = true;
        }
        if (left && !leftPressed)
        {
            left = false;
        }
        if (!right && rightPressed)
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed * 2.5f;
            right = true;
        }
        if (right && !rightPressed)
        {
            right = false;
        }
        if (Input.GetKeyDown("e") && !Input.GetKeyDown("q"))
        {
            transform.Rotate(Vector3.up,90);
        }
        else if (Input.GetKeyDown("q")&& !Input.GetKeyDown("e"))
        {
            transform.Rotate(Vector3.up, -90);
        }
    }
    
}
