using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : CharacterController
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform gunEndPoint;
    [SerializeField] Transform gunStartPoint;
    public override void UpdateBase()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var directionToShoot=(gunEndPoint.position-gunStartPoint.position).normalized;

        var bullet=Instantiate(bulletPrefab,gunEndPoint.position,Quaternion.identity);
        bullet.SetBulletDirection(directionToShoot);
    }
}
