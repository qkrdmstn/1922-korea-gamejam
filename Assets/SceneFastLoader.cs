using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFastLoader : MonoBehaviour
{
    public string sceneName;

    public void Awake()
    {
        SceneController.Instance.OnChangeScene(sceneName);
    }
}
