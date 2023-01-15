using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColliderController : CharacterController
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag(Tags.Ground.ToString()))
        {     
            Event_IsCharactCollideToGround?.Invoke(this,new CharacterCollideToGround
            {
                isHitToGround=true
            });
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag(Tags.Ground.ToString()))
        {     
            Event_IsCharactCollideToGround?.Invoke(this,new CharacterCollideToGround
            {
                isHitToGround=false
            });
        }
    }
}
