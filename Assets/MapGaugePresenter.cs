using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGaugePresenter : MonoBehaviour
{
    public GameObject playerObject;

    public Image fillImage;

    public PlayerController playerController;
    public GameObject clearUI;

    public GameManager manager;

    private bool isArrive = false;

    private void Awake()
    {

    }

    private void Update()
    {
        if( (playerObject.transform.position.z / 10000f) >= 0.95f && !isArrive)
        {
            isArrive = true;

            playerController.SetFrezzeMode(true);

            FadeManager.Instance.FadeIn(1f, () =>
            {
                AudioManager.instance.LoopAllStop();

                manager.GameClear();
                clearUI.SetActive(true);
                Destroy(playerController.gameObject);
                AudioManager.instance.PlaySFX("Clear");
                FadeManager.Instance.FadeOut(2f);
            });
        } 
        else
            fillImage.fillAmount = (playerObject.transform.position.z / 10000f);
    }

    public float GetMapPercent()
    {
        return playerObject.transform.position.z / 10000f;
    }
}
