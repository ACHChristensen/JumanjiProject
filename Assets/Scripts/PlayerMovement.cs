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
    private float speed = 500f;
    public PlayerInput playerInput;
    private Vector3 moveInput;
    private float jump = 10f;
    private float gravity = -10f;
    private float jumpHeight;

    void Start()
    {
        controller.SimpleMove(Vector3.forward * 0);
    }

    void FixedUpdate()
    {
        Vector2 inputMove = playerInput.actions["Movement"].ReadValue<Vector2>();
        moveInput = new Vector3(inputMove.x, 0f, inputMove.y);
        float verticalAxis = moveInput.z;
        float horizontalAxis = moveInput.x;

        if ((inputMove.y !=0f || inputMove.x != 0f ) && playerInput.actions["JumpMovement"].ReadValue<float>() <= 0)
        {
            Moves();
            
        }
        this.animation.SetFloat("vertical", verticalAxis);
        this.animation.SetFloat("horizental", horizontalAxis);
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
        if (moveInput.z < 0f)
            {
            moveInput += moveInput * Time.deltaTime * speed / 2;
            }
            else
            {
            moveInput += moveInput * Time.deltaTime * speed;
            }
        
    }




}
