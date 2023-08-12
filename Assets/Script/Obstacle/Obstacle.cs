using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType
{
    Sky,
    Sea
}
[System.Serializable]
public class Obstacle : MonoBehaviour
{
    public ObstacleType type;
    public ObstacleGenerator generator;
    private void Awake()
    {
        generator = FindObjectOfType<ObstacleGenerator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            if(type == ObstacleType.Sky)
                this.transform.position = generator.GetRandomPos(ObstacleType.Sky);
            else if (type == ObstacleType.Sea)
                this.transform.position = generator.GetRandomPos(ObstacleType.Sea);
        }
    }
}
