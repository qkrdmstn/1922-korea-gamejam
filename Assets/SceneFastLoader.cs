using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFastLoader : MonoBehaviour
{
    public string sceneName;


    [SerializeField] private bool isPass = false;

    public void Awake()
    {
        if (!isPass)
            ChangeScene();
    }

    public void ChangeScene()
    {
        SceneController.Instance.OnChangeScene(sceneName);
    }
}
