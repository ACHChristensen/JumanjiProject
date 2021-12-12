using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    public Animator animation;
    public CharacterController controller;
    private float speed = 175f;
    public PlayerInput playerInput;
    private Vector3 moveInput;
    private float jump = 2f;
    private float gravity = -2f;
    private float jumpHeight;

    void FixedUpdate()
    {
        Vector2 inputMove = playerInput.actions["Movement"].ReadValue<Vector2>();
        moveInput = new Vector3(inputMove.y, 0f, -1f*inputMove.x);
        float verticalAxis = inputMove.y;
        float horizontalAxis = inputMove.x;

        if ((inputMove.y !=0f || inputMove.x != 0f ) && playerInput.actions["JumpMovement"].ReadValue<float>() <= 0)
        {
            Moves();
            
        }
        this.animation.SetFloat("vertical", verticalAxis);
        this.animation.SetFloat("horizental", horizontalAxis);
        //moveInput.Normalize();

        /*if (moveInput != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveInput, Vector3.up);
            controller.transform.rotation = Quaternion.RotateTowards(controller.transform.rotation, toRotation, 20f * Time.deltaTime);
        }*/
        if (controller.isGrounded)
        {
            if (playerInput.actions["JumpMovement"].ReadValue<float>() > 0)
            {
               this.animation.SetTrigger("jump");
                jumpHeight = jump;
            }
           
        } 
         jumpHeight += gravity * Time.deltaTime;
       
       moveInput.y = jumpHeight;    
        controller.Move(moveInput * Time.deltaTime);

    }

    private void Moves()
    {
        moveInput.y = gravity * Time.deltaTime;

        if (moveInput.x < 0f)
        {
            moveInput += moveInput * Time.deltaTime * speed / 2;
        }
        else
        {
            moveInput += moveInput * Time.deltaTime * speed;
        }
        
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    
    public float GetSpeed()
    {
       return this.speed;
    }


}
