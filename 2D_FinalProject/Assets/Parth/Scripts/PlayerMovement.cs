using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalm = 0f;
    public float speed = 40f;
    bool jump = false;
    bool crouch = false;

    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        horizontalm = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalm));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        
    }

    public void OnLand()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouch (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }


    void FixedUpdate()
    {
        controller.Move(horizontalm * Time.fixedDeltaTime, crouch,jump);
        jump = false;
    }

}
