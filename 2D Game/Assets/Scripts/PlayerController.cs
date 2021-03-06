﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Player Movement Variables
    public int MoveSpeed;
    public float JumpHeight;
    private bool doubleJump;

    //player grounded variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    //non stick player
    private float moveVelocity;

    public Animator animator;


	// Use this for initialization
	void Start () {
        //animation reset
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
	}

	void FixedUpdate()
	{
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
        //nonstick player
        moveVelocity = 0f;
        // This code makes the character jump
        if(Input.GetKeyDown(KeyCode.W) && grounded){
            Jump();
        }

        //double jump
        if (grounded){
            doubleJump = false;
            animator.SetBool("isJumping", false);
        }
            
        

        if(Input.GetKeyDown (KeyCode.W) && !doubleJump && !grounded){
            Jump();
            doubleJump = true;
        }

        if (Input.GetKey(KeyCode.D)) {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = MoveSpeed;
            animator.SetBool("isRunning", true);

        }
        else if(Input.GetKeyUp(KeyCode.D)){
            animator.SetBool("isRunning", false);
        }
        if (Input.GetKey(KeyCode.A)) {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -MoveSpeed;
            animator.SetBool("isRunning", true);
        }
        else if(Input.GetKeyUp(KeyCode.A)){
            animator.SetBool("isRunning", false);
        }



        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        //player flip
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(1.732691f, 1.697154f, 1f);

        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-1.732691f, 1.697154f, 1f);
            
                 
	}

    public void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
        animator.SetBool("isJumping", true);
    }


}
