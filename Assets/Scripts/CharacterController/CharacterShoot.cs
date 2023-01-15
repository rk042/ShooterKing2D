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
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
    const float totalTime=0.2f;
    float timeCount=0;
    private void Shoot()
    {
        var directionToShoot=(MouseController.points-gunEndPoint.position).normalized;
        if (timeCount>totalTime )//&& ((transform.localScale.x<0 && directionToShoot.x<0) || (transform.localScale.x>0 && directionToShoot.x>0)))
        {
            UIManager.VFXSoundPlayer();
            timeCount=0;
            bulletPool.Get(out Bullet bullet);
            Debug.Log($"dir {directionToShoot}");
            bullet.SetBulletDirection(directionToShoot);
        }
        timeCount+=Time.deltaTime;
    }
}
