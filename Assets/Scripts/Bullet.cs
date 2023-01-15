using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveForce;
    private Vector2 direction;
    private Rigidbody2D myRd;
    
    private void Awake()
    {
        myRd=GetComponent<Rigidbody2D>();
    }
    public void SetBulletDirection(Vector2 newDirection)
    {
        direction=newDirection;
        myRd.AddForce(direction*moveForce,ForceMode2D.Impulse);
    }
}
