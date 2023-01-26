using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    [SerializeField] float moveSpeed=10;
    CharacterController characterController;
    private bool isStartGame;
    [SerializeField] ParticleSystem ps;

    private void Awake()
    {
        characterController = FindObjectOfType<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStartGame)
        {
            return;
        }

        if (Vector3.Distance(transform.position,characterController.transform.position)<1f)
        {
            Destroy(gameObject);
            return;
        }

       transform.position = Vector3.MoveTowards(transform.position,characterController.transform.position,Time.deltaTime*moveSpeed);
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag(Tags.Ground.ToString()))
        {
            isStartGame=true;
            // UIManager.ShakeScreen();
        }
        else
        {
            UIManager.UpdateScore();
            UIManager.ShakeScreen();
            UIManager.VFXEnemie();
            Instantiate(ps,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
