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

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            if(type == ObstacleType.Sky)
                this.transform.position = ObstacleGenerator.Instance.GetRandomPos(ObstacleType.Sky);
            else if (type == ObstacleType.Sea)
                this.transform.position = ObstacleGenerator.Instance.GetRandomPos(ObstacleType.Sea);
        }
    }
}
