using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HeneGames.Airplane;

public enum PlayerState
{
    IDLE = 0,
    FLY,
    DEAD
}

public class PlayerController : MonoBehaviour
{
    [field :SerializeField] public PlayerState CurrState { get; private set; }

    private StatusManager statusManager;
    private Rigidbody rig;

    [field: SerializeField] public float AccTime { get; private set; }
    private float timer = .0f;

    private bool isAction = false;

    [field:SerializeField] public AnimationCurve MoveUpCurve { get; private set; }
    [field:SerializeField] public float MoveUpTime { get; private set; }
    [field:SerializeField] public GameObject AddPowerPoint { get; private set; }
    public float movePower = .0f;

    private bool onLeftButton = false;

    private SimpleAirPlaneController controller;

    public UnityEvent<float> onHitEvent;
    public UnityEvent onDeadEvent;


    private void Awake()
    {
        TryGetComponent(out statusManager);
        TryGetComponent(out rig);
        TryGetComponent(out controller);

        SetFrezzeMode(false);
    }

    // 플레이어는 시간에 따라서 가속한다.
    // 물건에 부딪히거나 플레이어의 조건에 따라서 감속을 할 수 있다.
    // 플레이어의 고도 상승은 좌클릭을 통해서 진행한다.
    // 고도 하락은 가만히 있을 경우 진행된다.

    private void Update()
    {
        if (!isAction)
            return;

        timer += Time.deltaTime;

        if(timer >= AccTime)
        {
            timer = .0f;
            controller.AddCurrSpeed(1f);
        }

        if(Input.GetMouseButtonDown(0))
        {
            controller.SetCurrentSpeed(0f);
        }

    }

    private void SetFrezzeMode(bool isOn)
    {
        isAction = !isOn;

        if (isOn)
            rig.constraints = RigidbodyConstraints.FreezeAll;
        else
            rig.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    }

    public void Hit()
    {
        statusManager.GetStatus(StatusType.CURRENT_HP).SubValue(1f);

        if (statusManager.GetStatus(StatusType.CURRENT_HP).GetValue() <= 0)
        {
            Dead();

            return;
        }

        controller.SetCurrentSpeed(0f);
        onHitEvent?.Invoke(statusManager.GetStatus(StatusType.CURRENT_HP).GetValue());
    }

    private void Dead()
    {
        onDeadEvent?.Invoke();
    }
}
