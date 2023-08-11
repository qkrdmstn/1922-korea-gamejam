using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    private static ObstacleGenerator instance = null;

    public GameObject[] obstacles;
    public int numObstacle;
    public Vector3 mapStartPoint;
    public Vector3 mapEndPoint;
    //List<Vector3> posList = new List<Vector3>();

    private void Awake()
    {
        if(null == instance) //싱글톤
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        for(int i=0; i< numObstacle; i++)
        {
            int obstacle = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[obstacle], GetRandomPos(), Quaternion.identity);
        }
    }

    public Vector3 GetRandomPos() //범위 내의 랜덤 위치값 반환, 위치 List에 대입
    {

        //do //random Position 생성
        //{
        //    float randomX = Random.Range(mapStartPoint.x, mapEndPoint.x);
        //    float randomY = Random.Range(mapStartPoint.y, mapEndPoint.y);
        //    Vector3 randomPos = new Vector3(randomX, randomY, 0.0f);

        //    if (posList.Contains(randomPos)) //이미 List에 있는 위치
        //    {
        //        randomX = Random.Range(mapStartPoint.x, mapEndPoint.x);
        //        randomY = Random.Range(mapStartPoint.y, mapEndPoint.y);
        //        randomPos = new Vector3(randomX, randomY, 0.0f);
        //    }
        //    else
        //    {
        //        posList.Add(randomPos);
        //        return randomPos;
        //    }
        //}
        //while (true);

        float randomX = Random.Range(mapStartPoint.x, mapEndPoint.x);
        float randomY = Random.Range(mapStartPoint.y, mapEndPoint.y);
        Vector3 randomPos = new Vector3(randomX, randomY, 0.0f);
        return randomPos;
    }

    public static ObstacleGenerator Instance //오브젝트 생성자 접근 함수
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    
}
