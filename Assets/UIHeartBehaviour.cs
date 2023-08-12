using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHeartBehaviour : MonoBehaviour
{
    [field: SerializeField] public Sprite FullImage { get; private set; }
    [field: SerializeField] public Sprite  EmptyImage { get; private set; }

    [field: SerializeField] public Image currentImage { get; private set; }

    public void SetFullImage()
    {
        currentImage.sprite = FullImage;
    }

    public void SetEmptyImage()
    {
        currentImage.sprite = EmptyImage;
    }


}
