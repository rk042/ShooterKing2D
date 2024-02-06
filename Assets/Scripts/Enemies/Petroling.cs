using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Petroling : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform pointStart;
    [SerializeField] Transform pointEnd;

    private Transform tempPoint;

    // Start is called before the first frame update
    void Start()
    {
        tempPoint = pointEnd;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.State == GameState.GameOver)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, tempPoint.position, Time.deltaTime * moveSpeed);
            
        if (Vector3.Distance(transform.position,tempPoint.position)<0.1f)
        {
            if (tempPoint == pointStart)
            {
                tempPoint = pointEnd;
            }
            else
            {
                tempPoint = pointStart;
            }
        }
    }
}

