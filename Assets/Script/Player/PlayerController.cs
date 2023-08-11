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

    [Header("현재 상태")]
    [SerializeField] private PlayerState currState = PlayerState.IDLE;

    [field: Header("Flying")]
    [field: SerializeField] public AnimationCurve DownCurve { get; private set; }

    [field: Header("Running")]
    [field: SerializeField] public GameObject RigPoint { get; private set; }
    [field: SerializeField] public AnimationCurve UpCurve { get; private set; }
    [field: SerializeField] public GameObject TargetPosUp { get; private set; }
    [field: SerializeField] public GameObject FloaterGroup { get; private set; }

    public float power = .0f;

    private void Awake()
    {
        TryGetComponent(out rig);
        TryGetComponent(out gyroReceiver);

        ChangeState(PlayerState.RUNNING);

        // gyroReceiver.upMotionEvent.AddListener(AddRigYPoint);
        // 여기에서 Event 등록
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState(PlayerState.FLYING);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            ChangeState(PlayerState.RUNNING);
        }

        if(Input.GetMouseButtonDown(0))
        {
            OnRunUpPosY(power);
        }
    }

    private void FixedUpdate()
    {
    }


    private void ChangeState(PlayerState nextState)
    {
        if (currState == nextState)
            return;

        DebugWrap.Log($"{nextState}로 State를 Change 함.");

        switch ((int)currState)
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
        if (isOn)
        {
            if (currState != PlayerState.IDLE)
            {
                StartCoroutine(DownFly());
                rig.velocity = Vector3.zero;

                FloaterGroup.SetActive(true);
            }

            rig.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        }
        else
        {
            // Fly로 이동한다면, Floater Group False
            // Freeze 상태
            FloaterGroup.SetActive(false);
            rig.constraints = RigidbodyConstraints.FreezeAll;
        }

    }

    private void OnFlyingChanged(bool isOn)
    {
        // Upper Motion Only : Up Pos
        if (isOn)
        {
            // 공중 상승
            StartCoroutine(ClimbFly());
            rig.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        }
        else
        {
            // true 바꿔주고 Freeze 걸어주기
            rig.constraints = RigidbodyConstraints.FreezeAll;
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

    // Running ------------------------------------------------------------------------------------
    private void OnRunUpPosY(float power)
    {
        if (currState == PlayerState.RUNNING)
        {
            var veloPower = new Vector3(0, power, 0);
            rig.AddForceAtPosition(veloPower, RigPoint.transform.position, ForceMode.Acceleration);
            rig.AddForce(Vector3.one, ForceMode.Acceleration);
        }
        else if(currState ==PlayerState.FLYING)
        {
            rig.AddForce(new Vector3(0f, power, 0f), ForceMode.Acceleration);
        }
    }

    // Run -> Fly
    private IEnumerator ClimbFly()
    {
        var timer = .0f;
        var targetPos = TargetPosUp.transform.position;
        var startPos = transform.position;
        Vector3 currPos = Vector3.zero;

        // Rot
        var startRot = transform.rotation;
        // Curr Rot
        var currRot = Quaternion.identity;


        while (timer <= UpCurve.keys[UpCurve.length - 1].time)
        {
            currPos = Vector3.Lerp(startPos, targetPos, UpCurve.Evaluate(timer));
            currRot = Quaternion.Euler(Vector3.Lerp(startRot.eulerAngles, Vector3.zero, timer));

            transform.position = currPos;
            transform.rotation = currRot;

            yield return null;

            timer += Time.deltaTime / 3f;
        }
    }

    // Fly -> Run
    private IEnumerator DownFly()
    {
        var timer = .0f;
        var targetPos = transform.position;
        var offsetVec = new Vector3(5f, 0f, 0f);

        var startPos = transform.position;
        Vector3 vector3 = Vector3.zero;

        targetPos += offsetVec;
        targetPos.y = 0f;

        // Rot 
        var startRot = transform.rotation;
        // Curr
        var currRot = Quaternion.identity;

        while(timer <= DownCurve.keys[DownCurve.length - 1].time)
        {
            var currPos = transform.position;
            currPos = Vector3.Lerp(startPos, targetPos, DownCurve.Evaluate(timer));
            currRot = Quaternion.Euler(Vector3.Lerp(startRot.eulerAngles, Vector3.zero, timer));

            transform.position = currPos;
            transform.rotation = currRot;

            yield return null;

            timer += Time.deltaTime / 3f;
        }
    }

    // Flying ------------------------------------------------------------------------------------
}
