using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialStart : MonoBehaviour
{
    public UnityEvent onStart;

    private void Awake()
    {
    }

    public void OnStartProcess()
    {
        Debug.Log("Start!");

        onStart?.Invoke();
    }
}
