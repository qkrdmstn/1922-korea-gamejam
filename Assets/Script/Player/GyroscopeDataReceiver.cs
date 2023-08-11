using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GyroscopeDataReceiver : MonoBehaviour
{
    [HideInInspector] public UnityEvent<float> upMotionEvent;
    [HideInInspector] public UnityEvent downMotionEvent;
    private float gyroXvalue = .0f;

    private bool isOnMotion = false;
    private bool isDownMotion = false;

    [field: SerializeField] public int DefaultNumber { get; private set; }

    private void Awake()
    {
        Input.gyro.enabled = true;

        upMotionEvent.AddListener((x) =>
       {
           OnUpMotion(x);
       });

        downMotionEvent.AddListener(() =>
       {
           OnDownMotion();
       });
    }

    private void Update()
    {
        gyroXvalue = Input.gyro.rotationRate.x;
    }

    private void FixedUpdate()
    {
        // 일정 값 이상일 경우, 양수는 Upper
        if (gyroXvalue >= DefaultNumber && !isOnMotion)
        {
            isOnMotion = true;

            upMotionEvent?.Invoke(gyroXvalue);
        }
        else if(gyroXvalue <= -DefaultNumber && !isDownMotion)
        {
            // 일정 값보다 작으면, 음수는 Down
            isDownMotion = false;

            downMotionEvent?.Invoke();
        }
    }

    private void OnApplicationQuit()
    {
        Input.gyro.enabled = false;
    }

    private void OnUpMotion(float data)
    {
        DebugWrap.Log($"Motion On");

        isOnMotion = false;
    }

    private void OnDownMotion()
    {
        DebugWrap.Log($"Motion Down");

        isDownMotion = false;
    }
}
