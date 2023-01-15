using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : CharacterController
{
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;

    Rigidbody2D myRd;
    bool canJump;

    private void Awake()
    {
        myRd=GetComponent<Rigidbody2D>();
    }
    
    private void OnEnable()
    {
        CharacterController.Event_IsCharactCollideToGround+=IsCollideToGround;   
    }
   
    private void OnDisable()
    {
        CharacterController.Event_IsCharactCollideToGround-=IsCollideToGround;  
    }
    
    private void JumpControll()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            myRd.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
    }

    private void MoveControll()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        if (horizontalMove<0)
        {
            transform.localScale=new Vector3(-1,2,1);
        }
        else if(horizontalMove>0)
        {
            transform.localScale=new Vector3(1,2,1);
        }
        myRd.velocity=new Vector2(horizontalMove*moveSpeed,myRd.velocity.y);
    }
    
    private void IsCollideToGround(object sender, CharacterCollideToGround e)
    {
        canJump=e.isHitToGround;
    }

    public override void UpdateBase()
    {
        MoveControll();
        JumpControll();
    }
}
