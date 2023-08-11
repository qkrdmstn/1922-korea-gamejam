using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObstacleKind
{
    A,
    B,
    C
}

public class Obstacle : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            this.transform.position = ObstacleGenerator.Instance.GetRandomPos();
        }
    }
}
