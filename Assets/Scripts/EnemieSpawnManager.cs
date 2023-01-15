using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpawnManager : MonoBehaviour
{
    [SerializeField] Transform point1;
    [SerializeField] Transform point2;
    [SerializeField] float spawnTime=1f;
    [SerializeField] Enemie enemie;

    private float timeCount;

    // Update is called once per frame
    void Update()
    {
        if (timeCount>spawnTime)
        {
            timeCount=0;
            var position=new Vector3(Random.Range(point1.position.x,point2.position.x),point1.position.y,point1.position.z);
            Instantiate(enemie,position,Quaternion.identity);
        }

        timeCount+=Time.deltaTime;
    }
}
