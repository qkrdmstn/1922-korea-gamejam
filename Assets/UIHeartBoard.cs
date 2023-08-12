using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHeartBoard : MonoBehaviour
{
    [field: SerializeField] public UIHeartBehaviour[] HeartBoards { get; private set; }
    [field: SerializeField] public PlayerController Player { get; private set; }

    private void Awake()
    {
        UpdatePlayerBoard(3);

        Player.onHitEvent.AddListener((x) =>
       {
           UpdatePlayerBoard(x);
       });
    }

    private void Update()
    {
    }

    private void UpdatePlayerBoard(float hp)
    {
        for (int i = 0; i < HeartBoards.Length; ++i)
        {
            HeartBoards[i].SetEmptyImage();
        }

        for (int i = 0; i < hp; ++i)
        {
            HeartBoards[i].SetFullImage();
        }
    }


}
