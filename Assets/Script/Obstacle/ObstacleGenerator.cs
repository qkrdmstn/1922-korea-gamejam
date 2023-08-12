using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator :MonoBehaviour
{
    public GameObject[] skyObstacles; //장애물 생성
    public GameObject[] seaObstacles;
    public int[] numObstacle;

    //Obstacle Bound
    public float skyUpperBound;
    public float skyLowerBound;
    public float seaLowerBound = 0;
    public float XBound;
    
    public Transform tf;
    public GameObject OBparent;
    private PlayerUpperLimit upperLimit;

    private GameManager manager; //Obstacle Generate Period
    public float skyObPeriod;
    public float skyObTimer;
    private int index1;

    public float seaObPeriod;
    public float seaObTimer;

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<GameManager>();

        //skyUpperBound = upperLimit.MaxY;
    }

    private void Update()
    {
        skyObTimer += Time.deltaTime;
        seaObTimer += Time.deltaTime;

        if(skyObTimer > skyObPeriod)
        {
            skyObTimer = 0;
            GenerateSkyObstacle(index1);
            index1++;
            if (index1 >= numObstacle.Length - 1)
                index1--;
        }

        if (seaObTimer > seaObPeriod)
        {
            seaObTimer = 0;
            GenerateSeaObstacle();
        }
    }


    public void GenerateSkyObstacle(int index) //시간마다 index 조절해서 호출하기
    {
        for(int i=0; i< numObstacle[index]; i++)
        {
            int obstacle = Random.Range(0, skyObstacles.Length - 1);
            Instantiate(skyObstacles[obstacle], GetRandomPos(true), Quaternion.identity, OBparent.transform);
        }
    }
    public void GenerateSeaObstacle() //시간마다 index 조절해서 호출하기
    {
        int obstacle = Random.Range(0, seaObstacles.Length - 1);
        Instantiate(seaObstacles[obstacle], GetRandomPos(false), Quaternion.identity, OBparent.transform);
      
    }

    public Vector3 GetRandomPos(bool isSky) //바다 장애물이면 Y값 0으로 고정
    {
        float randomX = Random.Range(tf.position.x, XBound);
        float randomY = new float();

        if (isSky)
            randomY = Random.Range(skyLowerBound, skyUpperBound);
        else
            randomY = 0.0f;

        Vector3 randomPos = new Vector3(randomX, randomY, 0.0f);

       return randomPos;
    }
}
