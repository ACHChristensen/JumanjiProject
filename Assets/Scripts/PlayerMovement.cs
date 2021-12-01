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
    private float speed = 12f;
    public PlayerInput playerInput;
    private Vector3 moveInput;
    private Vector3 playerVelocity;
    private float jump = 7.0f;
    private float gravity = 9.82f;

    void Start()
    {


    }

    void FixedUpdate()
    {
        Moves();

    }

    private void Moves()
    {

        /*if ()
        {*/
        Debug.Log(controller.isGrounded);

            Vector2 inputMove = playerInput.actions["Movement"].ReadValue<Vector2>();
            moveInput = new Vector3(inputMove.x, 0f, inputMove.y);
            
            
            
        if (moveInput.z < 0f)
            {
                controller.Move(moveInput * Time.deltaTime * speed / 2);
            }
            else
            {
                controller.Move(moveInput * Time.deltaTime * speed);
            }
        
        if (playerInput.actions["JumpMovement"].ReadValue<float>()>0)
        {
            Jump(); 
        }
            float verticalAxis = moveInput.x;
            float horizontalAxis = moveInput.z;

            this.animation.SetFloat("vertical", verticalAxis);
            this.animation.SetFloat("horizental", horizontalAxis);
        //}
            
    }

    private void Jump()
    {
        this.animation.SetBool("jump", true);
        playerVelocity = moveInput;
        playerVelocity.y += Mathf.Sqrt(jump * -1.0f * gravity);
        controller.Move(playerVelocity * Time.fixedDeltaTime);
        playerVelocity.y += gravity * Time.fixedDeltaTime;
        controller.Move(playerVelocity * Time.fixedDeltaTime);
    }



}
