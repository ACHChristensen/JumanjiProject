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
    private float jump = 9.0f;
    private float gravity = -9.3f;

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

        if ((moveInput.y !=0f || moveInput.x != 0f ) && playerInput.actions["JumpMovement"].ReadValue<float>() <= 0)
        {
            Moves();
            
        }
        this.animation.SetFloat("vertical", verticalAxis);
        this.animation.SetFloat("horizental", horizontalAxis);

        if (playerInput.actions["JumpMovement"].ReadValue<float>() > 0 && controller.isGrounded)
        {
            this.animation.SetBool("jump", true);
            playerVelocity = moveInput;
            playerVelocity.y += Mathf.Sqrt(jump * -1.0f * gravity);
            controller.Move(playerVelocity * Time.deltaTime);
        }
        else if (!controller.isGrounded){ 
            playerVelocity.y += gravity * Time.deltaTime;
        }
        else
        {
            this.animation.SetBool("jump", false);
        }
        
        controller.Move(playerVelocity * Time.deltaTime);

    }

    private void Moves()
    {

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
        
    }




}
