using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour,IEnemieData
{
    [SerializeField] float moveSpeed=10;
    [field:SerializeField] public int DemageAmountToPlayer { get; private set; }
    public bool IsStartGame { get; set; }

    private GameObject player;
    private Petroling petroling;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player.ToString());
        petroling = GetComponent<Petroling>();
    }

    void Update()
    {
        if (!IsStartGame || !player || GameManager.Instance.State == GameState.GameOver)
        {
            return;
        }

        if (Vector3.Distance(transform.position,player.transform.position)<1f)
        {
            return;
        }
        if (!petroling)
        {
            transform.position = Vector3.MoveTowards(transform.position,player.transform.position,Time.deltaTime*moveSpeed);
        }
    }
}
