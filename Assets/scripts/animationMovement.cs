using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationMovement : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool Ide = animator.GetBool("Ide?");
        bool Idedozadu = animator.GetBool("Idedozadu?");
        bool Side = animator.GetBool("Side?");
        bool fowardPressed = Input.GetKey("w");
        bool backPressed = Input.GetKey ("s");
        bool sidePressed = Input.GetKey("d");
        if (!Ide && fowardPressed)
        {
            animator.SetBool("Ide?",true);
        }
        if (Ide &&!fowardPressed)
        {
            animator.SetBool("Ide?", false);
        }
        if (!Idedozadu && backPressed)
        {
            animator.SetBool("Idedozadu?", true);
        }
        if (Idedozadu && !backPressed)
        {
            animator.SetBool("Idedozadu?", false);
        }
        if (!Side && sidePressed)
        {
            animator.SetBool("Side?", true);
        }
        if (Side && !sidePressed)
        {
            animator.SetBool("Side?", false);
        }
    }
}
