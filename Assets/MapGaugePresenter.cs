using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGaugePresenter : MonoBehaviour
{
    public GameObject playerObject;

    public Image fillImage;

    private void Awake()
    {

    }

    private void Update()
    {
        fillImage.fillAmount = (playerObject.transform.position.z / 10000f);
    }

    public float GetMapPercent()
    {
        return playerObject.transform.position.z / 10000f;
    }
}
