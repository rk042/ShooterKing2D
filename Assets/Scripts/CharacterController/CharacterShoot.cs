using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CharacterShoot : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform gunEndPoint;
    [SerializeField] Transform gunStartPoint;
    [SerializeField] private int defaultCapacity=10;
    [SerializeField] private int maxSize=20;

    ObjectPool<Bullet> bulletPool;
    bool collectionCheck;
    const float totalTime = 0.2f;
    float timeCount = 0;
    const int bulletCount = 10;
    int tempbulletCount;

    private void Awake()
    {
        bulletPool=new ObjectPool<Bullet>(CreateFunc,ActionOnGet,ActionOnRelease,ActionOnDestroy,collectionCheck,defaultCapacity,maxSize);
    }

    private void ActionOnDestroy(Bullet obj)
    {
        Destroy(obj.gameObject);
    }

    private void ActionOnRelease(Bullet obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void ActionOnGet(Bullet obj)
    {
        obj.transform.position=gunEndPoint.position;
        obj.gameObject.SetActive(true);
    }

    private Bullet CreateFunc()
    {
        var bullet=Instantiate(bulletPrefab,gunEndPoint.position,Quaternion.identity);
        bullet.ObjectPool=bulletPool;
        return bullet;
    }

    public void Update()
    {
        if (GameManager.Instance.State == GameState.GameOver)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        var directionToShoot=(MouseController.points-gunEndPoint.position).normalized;
        
        if (timeCount>totalTime)
        {
            SFXPlayer.SFXSoundPlayer();
            timeCount=0;
            bulletPool.Get(out Bullet bullet);
            bullet.SetBulletDirection(directionToShoot);
        }
        
        timeCount+=Time.deltaTime;
    }
}
