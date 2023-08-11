using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUpperLimit : MonoBehaviour
{
    [field: SerializeField] public float MaxY { get; private set; }

    [HideInInspector] public UnityEvent onLimitEvent;

    private void Update()
    {
        if(transform.position.y >= MaxY)
        {
            onLimitEvent?.Invoke();
        }
    }

    public void Test()
    {
        Debug.Log("Upper Percent" + GetUpperPercent());
    }
    public float GetUpperPercent()
    {
        return transform.position.y / MaxY;
    }

    public float GetUpperPos()
    {
        return transform.position.y;
    }

    public float GetMaxUpper()
    {
        return MaxY;
    }

    private void OnDrawGizmos()
    {
        var startVec = transform.position;
        var endVec = new Vector3(startVec.x, MaxY, startVec.z);
        startVec.y = 0f;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(startVec, endVec);
        Gizmos.DrawCube(endVec, Vector3.one);

    }
}
