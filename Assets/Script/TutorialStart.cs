using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialStart : MonoBehaviour
{
    public UnityEvent onStart;

    private void Update()
    {
        if(Time.timeScale == 0)
            Time.timeScale = 1;
    }

    public void OnStartProcess()
    {
        FadeManager.Instance.FadeIn(1f, () =>
        {
            AudioManager.instance.PlaySFX("Click");

            onStart?.Invoke();
            SceneController.Instance.OnChangeScene("Game");

            FadeManager.Instance.FadeOut(1f, () => { 
            
            });
        });
    }
}
