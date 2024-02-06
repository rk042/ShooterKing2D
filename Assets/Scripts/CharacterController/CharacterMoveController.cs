using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CharacterMoveController : MonoBehaviour, ICharacterJump
{
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;

    Rigidbody2D myRd;

    private int DoubleJump = 0;

    private void Awake()
    {
        myRd = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (GameManager.Instance.State == GameState.GameOver)
        {
            return;    
        }

        MoveControll();
        JumpControll();
    }

    private void JumpControll()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DoubleJump<2)
        {
            myRd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            SFXPlayer.SFXJump();
            DoubleJump++;
        }
    }

    private void MoveControll()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        if (horizontalMove < 0)
        {
            transform.localScale = new Vector3(-1, 2, 1);
        }
        else if (horizontalMove > 0 )
        {
            transform.localScale = new Vector3(1, 2, 1);
        }
        myRd.velocity = new Vector2(horizontalMove * moveSpeed, myRd.velocity.y);
    }

    void ICharacterJump.HitGround()
    {
        DoubleJump = 0;
    }
}
