using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObstacleType
{
    Sky,
    Sea
}

[SerializeField]
public class Obstacle : MonoBehaviour
{
    public ObstacleGenerator generator;
    public float obstacleSpeed;
    public ObstacleType type;
    public Transform destroyPos;

    protected void Awake()
    {
        destroyPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        generator = FindObjectOfType<ObstacleGenerator>();
        //Debug.Log("o");
    }

    private void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, 0, -1 * obstacleSpeed * Time.deltaTime));

       // Debug.Log(destroyPos);
        if (gameObject.transform.position.z < destroyPos.position.z - 50)
        {
            Destroy(this.gameObject);
        }

    }

    protected void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            if(type == ObstacleType.Sky)
               this.transform.position = generator.GetRandomPos(true);
            else if (type == ObstacleType.Sea)
                this.transform.position = generator.GetRandomPos(false);
        }
    }
}
