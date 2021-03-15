using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    Animator animator;
    PlayerController controller;
    int isRunningHash;
    int isJumpingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<PlayerController>();
        // code optimisation
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        bool isRunning = animator.GetBool("isRunning");
        if (controller.isMoving)
        {
            animator.SetBool(isRunningHash, true);
        }
        else
        {
            animator.SetBool(isRunningHash, false);
        }

        bool isJumping = animator.GetBool("isJumping");
        if (!controller.isGrounded)
        {
            animator.SetBool(isJumpingHash, true);
        }
        else
        {
            animator.SetBool(isJumpingHash, false);
        }

        //if (!isRunning && forwardPress)
        //{
        //    animator.SetBool(isRunningHash, true);
        //}

        //if (isRunning && !forwardPress)
        //{
        //    animator.SetBool(isRunningHash, false);
        //}
    }
}
