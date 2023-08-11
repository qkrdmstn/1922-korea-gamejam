using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator :MonoBehaviour
{
    public GameObject[] skyObstacles; //장애물 생성
    public GameObject[] seaObstacles;
    public int[] numObstacle;
    public float skyUpperBound;
    public float skyLowerBound;
    public float seaUpperBound;
    public float seaLowerBound = 0;
    public float XBound;
    public Transform tf;
    public GameObject OBparent;
    private PlayerUpperLimit upperLimit;


    private void Awake()
    {
        //skyUpperBound = upperLimit.MaxY;
    }

    private void Update()
    {
        if (GameManager.Instance.playTime >= 10)
            GenerateObstacle(0);
        if (GameManager.Instance.playTime >= 40)
            GenerateObstacle(1);
    }

    //시간마다 numObstacle 
    public void GenerateObstacle(int index) //시간마다 index 조절해서 호출하기
    {
        int numSkyObstacle = Random.Range(0, numObstacle[index]);
        int numSeaObstacle = numObstacle[index] - numSkyObstacle;

        for(int i=0; i<numSkyObstacle; i++)
        {
            int obstacle = Random.Range(0, skyObstacles.Length);
            Instantiate(skyObstacles[obstacle], GetRandomPos(ObstacleType.Sky), Quaternion.identity, OBparent.transform);
        }
        for (int i = 0; i < numSeaObstacle; i++)
        {
            int obstacle = Random.Range(0, seaObstacles.Length);
            Instantiate(seaObstacles[obstacle], GetRandomPos(ObstacleType.Sea), Quaternion.identity, OBparent.transform);
        }
    }


    public Vector3 GetRandomPos(ObstacleType type) 
    {
        float randomX = new float();
        float randomY = new float();

        randomX = Random.Range(tf.position.x, XBound);
        if (type == ObstacleType.Sky)
        { 
            randomY = Random.Range(skyLowerBound, skyUpperBound);
           
        }
        else if(type == ObstacleType.Sea)
        {
            randomY = Random.Range(seaLowerBound, seaUpperBound);
        }

        Vector3 randomPos = new Vector3(randomX, randomY, 0.0f);
        return randomPos;
    }
}
