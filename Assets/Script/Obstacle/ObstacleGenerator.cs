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
        if(null == instance) //�̱���
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

    public Vector3 GetRandomPos() //���� ���� ���� ��ġ�� ��ȯ, ��ġ List�� ����
    {

        //do //random Position ����
        //{
        //    float randomX = Random.Range(mapStartPoint.x, mapEndPoint.x);
        //    float randomY = Random.Range(mapStartPoint.y, mapEndPoint.y);
        //    Vector3 randomPos = new Vector3(randomX, randomY, 0.0f);

        //    if (posList.Contains(randomPos)) //�̹� List�� �ִ� ��ġ
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

    public static ObstacleGenerator Instance //������Ʈ ������ ���� �Լ�
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
