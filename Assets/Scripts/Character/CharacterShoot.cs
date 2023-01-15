using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CharacterShoot : CharacterController
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform gunEndPoint;
    [SerializeField] Transform gunStartPoint;
    ObjectPool<Bullet> bulletPool;
    private bool collectionCheck;
    [SerializeField] private int defaultCapacity=10;
    [SerializeField] private int maxSize=20;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        bulletPool=new ObjectPool<Bullet>(createFunc,actionOnGet,actionOnRelease,actionOnDestroy,collectionCheck,defaultCapacity,maxSize);
    }

    private void actionOnDestroy(Bullet obj)
    {
        Destroy(obj.gameObject);
    }

    private void actionOnRelease(Bullet obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void actionOnGet(Bullet obj)
    {
        obj.transform.position=gunEndPoint.position;
        obj.gameObject.SetActive(true);
    }

    private Bullet createFunc()
    {
        var bullet=Instantiate(bulletPrefab,gunEndPoint.position,Quaternion.identity);
        bullet.ObjectPool=bulletPool;
        return bullet;
    }

    public override void UpdateBase()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        bulletPool.Get(out Bullet bullet);
        var directionToShoot=(gunEndPoint.position-gunStartPoint.position).normalized;
        bullet.SetBulletDirection(directionToShoot);
    }
}
