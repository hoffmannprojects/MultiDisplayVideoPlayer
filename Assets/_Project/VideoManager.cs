using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    private const string videoUrl = "D:\\Tim\\Documents\\Github\\MultiDisplayVideoPlayer\\file.mov";
    private VideoPlayer videoPlayer;

    // Use this for initialization
    void Start()
    {
        videoPlayer = Camera.main.GetComponent<VideoPlayer>();
        Assert.IsNotNull(videoPlayer);

        videoPlayer.url = videoUrl;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TogglePlayback ()
    {
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
        else
        {
            videoPlayer.Stop();
        }
    }
}
