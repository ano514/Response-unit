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
        bool SideBack = animator.GetBool("Sidedozadu?");
        bool aim = animator.GetBool("aim");
        bool fowardPressed = Input.GetKey("w");
        bool backPressed = Input.GetKey ("s");
        bool sidePressed = Input.GetKey("d");
        bool sideBackPressed= Input.GetKey("a");
        bool aimPressed = Input.GetKey(KeyCode.Mouse1);
        if (!Ide && fowardPressed && !backPressed && !sidePressed && !sideBackPressed)
        {
            animator.SetBool("Ide?",true);
        }
        if (Ide &&!fowardPressed|| Ide && fowardPressed && backPressed || Ide && fowardPressed && sidePressed || Ide && fowardPressed && sideBackPressed)
        {
            animator.SetBool("Ide?", false);
        }
        if (!Idedozadu && backPressed && !fowardPressed && !sidePressed && !sideBackPressed)
        {
            animator.SetBool("Idedozadu?", true);
        }
        if (Idedozadu && !backPressed || Idedozadu && backPressed && fowardPressed || Idedozadu && backPressed && sidePressed || Idedozadu && backPressed && sideBackPressed)
        {
            animator.SetBool("Idedozadu?", false);
        }
        if (!Side && sidePressed && !backPressed && !fowardPressed && !sideBackPressed)
        {
            animator.SetBool("Side?", true);
        }
        if (Side && !sidePressed || Side && sidePressed &&fowardPressed || Side && sidePressed && backPressed || Side && sidePressed && sideBackPressed)
        {
            animator.SetBool("Side?", false);
        }
        if ( !SideBack && sideBackPressed && !backPressed && !fowardPressed && !sidePressed)
        {
            animator.SetBool("Sidedozadu?", true);
        }
        if (SideBack && !sideBackPressed || SideBack && sideBackPressed && fowardPressed || SideBack && sideBackPressed && backPressed || SideBack && sideBackPressed && sidePressed)
        {
            animator.SetBool("Sidedozadu?", false);
        }
        if (!aim && aimPressed)
        {
            animator.SetBool("aim", true);
        }
        if (aim && !aimPressed)
        {
            animator.SetBool("aim", false);
        }
    }
}
