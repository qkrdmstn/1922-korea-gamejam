using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoCloser : MonoBehaviour
{
    public GameObject videoImage;

    private VideoPlayer video;
    private bool onVideo = false;

    private void Awake()
    {
        TryGetComponent(out video);

        video.loopPointReached += RemoveImage;
    }

    private void Update()
    {
        if(video.isPrepared && !onVideo)
        {
            onVideo = true;

            FadeManager.Instance.FadeOut(1f);
        }
    }

    private void RemoveImage(VideoPlayer vp)
    {
        FadeManager.Instance.FadeIn(0.1f, () =>
        {
            videoImage.SetActive(false);

            FadeManager.Instance.FadeOut(1f);
        });
    }

}
