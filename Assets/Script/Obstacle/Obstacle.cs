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

    private void Awake()
    {
        destroyPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Debug.Log(GameObject.FindGameObjectWithTag("Player"));
        generator = FindObjectOfType<ObstacleGenerator>();
        //Debug.Log("o");
    }

    private void Update()
    {
        this.gameObject.transform.Translate(new Vector3(-1 * obstacleSpeed * Time.deltaTime, 0, 0));

       // Debug.Log(destroyPos);
        if (gameObject.transform.position.x < destroyPos.position.x)
            Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
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
