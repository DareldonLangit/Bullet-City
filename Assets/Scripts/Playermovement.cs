using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Playermovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator; 
    public float moveSpeed;
    public Joystick joystick;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        //FOR KEYBOARD
        //horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        //FOR JOYSTICK

        if(joystick.Horizontal >= .2f)
        {
            horizontalMove = moveSpeed;

        }else if(joystick.Horizontal <= -.2f)
        {
            horizontalMove = -moveSpeed;

        }
        else
        {
            horizontalMove = 0f;
        }


        //JUMPING AND CROUCHING FOR KEYBOARD
        try
        {
            animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        }
        catch (Exception e)
        {

        }


        //if (Input.GetButtonDown("Jump"))
        //{
        //    jump = true;
        //    animator.SetBool("isJumping", true);
        //}

        //if (Input.GetButtonDown("Crouch")) 
        //{
        //    crouch = true;
        //}else if (Input.GetButtonUp("Crouch"))
        //{
        //    crouch = false;
        //}

    }

    private void FixedUpdate()
    {
        //Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }


    //FOR JOYSTICK AND BUTTONS
    //public void Shoot()
    //{

    //}

    public void Jump()
    {
        jump = true;
        animator.SetBool("isJumping", true);
    }
}
