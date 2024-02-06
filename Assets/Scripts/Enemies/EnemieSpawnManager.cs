using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpawnManager : MonoBehaviour
{
    [SerializeField] Transform point1;
    [SerializeField] Transform point2;
    [SerializeField] float spawnTime=.5f;
    [SerializeField] Enemie enemie;
    [SerializeField] SOLevel SOLevel;

    private float timeCount;
    private Vector3 spawnPosition;
    private bool startSpawning;
   
    private void Awake()
    {
        if (SOLevel == null)
        {
            throw new System.Exception("SO Level is null");
        }
    }

    void Update()
    {
        if (GameManager.Instance.State == GameState.GameOver)
        {
            return;
        }
        if (!startSpawning)
        {
            return;
        }

        Spawning();
    }

    private void Spawning()
    {
        if (timeCount > spawnTime)
        {
            timeCount = 0;
            spawnPosition = new Vector3(Random.Range(point1.position.x, point2.position.x), point1.position.y, point1.position.z);
            Instantiate(enemie, spawnPosition, Quaternion.identity);
        }

        timeCount += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Player.ToString()))
        {
            startSpawning = true;

            SFXPlayer.SFXEnemieDetected();
        }
    }
}
