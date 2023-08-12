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


    private void Awake()
    {
        TryGetComponent(out statusManager);
        TryGetComponent(out rig);
        TryGetComponent(out controller);

        SetFrezzeMode(false);
    }

    // �÷��̾�� �ð��� ���� �����Ѵ�.
    // ���ǿ� �ε����ų� �÷��̾��� ���ǿ� ���� ������ �� �� �ִ�.
    // �÷��̾��� �� ����� ��Ŭ���� ���ؼ� �����Ѵ�.
    // �� �϶��� ������ ���� ��� ����ȴ�.

    private void Update()
    {
        if (!isAction)
            return;

        timer += Time.deltaTime;

        if(timer >= AccTime)
        {
            timer = .0f;
            controller.AddCurrSpeed(1f);
            // �����ϴ� ������ �̰����� ó���Ѵ�.
        }

        // onLeftButton = Input.GetMouseButton(0);

        rig.AddForce(Vector3.right * movePower * Time.deltaTime, ForceMode.Force);
    }

    private void FixedUpdate()
    {
        if(onLeftButton)
        {
            var power = new Vector3(0f, movePower, 0f);
            rig.AddForceAtPosition(power, AddPowerPoint.transform.position, ForceMode.Acceleration);
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



}
