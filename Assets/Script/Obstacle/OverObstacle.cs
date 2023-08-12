using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverObstacle : Obstacle
{
    private GameManager manager;
    private void Awake()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.GameOver();
        }

    }
}
