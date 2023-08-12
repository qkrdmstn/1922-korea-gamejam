using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObstacle : Obstacle
{
    private GameManager manager;

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
        //generator = FindObjectOfType<ObstacleGenerator>();
        //destroyPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        base.Awake();
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Player�� Current_HP �� -1 �ϱ�
            Debug.Log("Attack Obstacle Hit");
        }

    }
}
