using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerState
{
    IDLE = -1,
    FLYING = 0,
    RUNNING,
    DEATH
}

public class PlayerController : MonoBehaviour
{
    private GyroscopeDataReceiver gyroReceiver;
    private Rigidbody rig;

    [SerializeField] private PlayerState currState;
    [field: SerializeField] public GameObject rigPoint { get; private set; }

    public float maxPower;

    private void Awake()
    {
        TryGetComponent(out rig);
        TryGetComponent(out gyroReceiver);

        ChangeState(PlayerState.IDLE);
        // gyroReceiver.upMotionEvent.AddListener(AddRigYPoint);
        // 여기에서 Event 등록
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddRigYPoint(maxPower);
        }
    }

    private void FixedUpdate()
    {
    }


    private void ChangeState(PlayerState nextState)
    {
        DebugWrap.Log($"{nextState}로 State를 Change 함.");

        switch((int)currState)
        {
            case 0:
                OnFlyingChanged(false);
                break;

            case 1:
                OnRunningChanged(false);
                break;

            case 2:
                OnDeath(false);
                break;
        }

        currState = nextState;

        switch ((int)currState)
        {
            case 0:
                OnFlyingChanged(true);
                break;

            case 1:
                OnRunningChanged(true);
                break;

            case 2:
                OnDeath(true);
                break;
        }

    }

    // True : Enter
    // False : Exit
    private void OnRunningChanged(bool isOn)
    {
        // Upper Motion Only : Upper Boat
        if(isOn)
        {

        }
        else
        {

        }

    }

    private void OnFlyingChanged(bool isOn)
    {
        if (isOn)
        {

        }
        else
        {

        }
    }

    private void OnDeath(bool isOn)
    {
        if (isOn)
        {

        }
        else
        {

        }
    }

    private void AddRigYPoint(float power)
    {
        var veloPower = new Vector3(0, power, 0);
        rig.AddForceAtPosition(veloPower, rigPoint.transform.position, ForceMode.Acceleration);
    }

}
