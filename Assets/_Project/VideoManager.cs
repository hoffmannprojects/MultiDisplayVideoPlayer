using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;
using UnityEngine.Video;

public class VideoManager : NetworkBehaviour
{
    private const string videoUrl = "D:\\Tim\\Documents\\Github\\MultiDisplayVideoPlayer\\file.mov";
    private VideoPlayer videoPlayer;

    [SyncVar]
    private bool networkPlaybackStarted = false;

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
        //if (networkPlaybackStarted)
        //{
        //    videoPlayer.Play();
        //}
        //else
        //{
        //    videoPlayer.Stop();
        //}

    }
    [Command]
    public void CmdTogglePlayback ()
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
