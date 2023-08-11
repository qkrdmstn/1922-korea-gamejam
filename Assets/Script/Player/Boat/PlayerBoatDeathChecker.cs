using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoatDeathChecker : MonoBehaviour
{
    private bool isDeath = false;
    private void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, Vector2.up * 3f);
    }
}
