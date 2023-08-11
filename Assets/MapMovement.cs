using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    public GameObject maps;

    public float moveSpeed = .0f;

    public List<GameObject> map;
    private GameObject currMap;

    private int currIndex = 1;

    private void Awake()
    {
        currMap = map[0];
    }


    private void Update()
    {
        if (Mathf.Abs(maps.transform.position.x) >= (300f * currIndex))
        {
            ChangedMap();
        }
        else
            maps.transform.Translate(Vector3.left* Time.deltaTime * moveSpeed);
    }

    private void ChangedMap()
    {
        currIndex++;

        currMap.transform.localPosition = new Vector3(currIndex * 300f, 0f, 0f);
        Debug.Log(currIndex + " : " + 300f * currIndex);

        currMap = map[ (currIndex + 1) % 2];
    }
}
