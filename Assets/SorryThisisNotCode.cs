using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorryThisisNotCode : MonoBehaviour
{
    public float rotatePower = .0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotatePower);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * rotatePower);
        }
    }
    
}
