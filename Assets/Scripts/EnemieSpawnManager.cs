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
    private int spawnTrackCount;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        spawnTrackCount=10;
    }
    // Update is called once per frame
    void Update()
    {
        if (UIManager.scoreCount>spawnTrackCount)
        {
            spawnTrackCount+=10;
            spawnTime-=0.25f;
        }

        if (timeCount>spawnTime)
        {
            UIManager.VFXLevelUp();
            timeCount=0;
            var position=new Vector3(Random.Range(point1.position.x,point2.position.x),point1.position.y,point1.position.z);
            Instantiate(enemie,position,Quaternion.identity);
        }

        timeCount+=Time.deltaTime;
    }
}
