using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class UIGood : MonoBehaviour
{
    public VideoPlayer vp;

    private bool isOn = false;

    private float timer = .0f;

    private void Awake()
    {
        vp.loopPointReached += OnEndVideo;
    }

    private void Update()
    {
        vp.Prepare();

        if(vp.isPrepared)
            timer += Time.deltaTime;


        if(vp.isPrepared && !isOn  && timer >= 3f)
        {
            isOn = true;

            FadeManager.Instance.FadeOut(1f, () =>
            {
                vp.Play();
            });
        }
    }

    private void OnEndVideo(VideoPlayer vps)
    {
        FadeManager.Instance.FadeIn(0.1f, () =>
        {
            SceneController.Instance.OnChangeScene("Title");

            FadeManager.Instance.FadeOut(1f);
        });
    }
}
