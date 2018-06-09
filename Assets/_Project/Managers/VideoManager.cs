using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;
using UnityEngine.Video;

public class VideoManager : NetworkBehaviour
{
    private const string videoUrl = "file.mp4";
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

    // Called from the client, run on the server.
    [Command]
    public void CmdTogglePlayback ()
    {
        Debug.Log("Called CmdTogglePlayback from client.");
        RpcTogglePlayback();
    }

    // Called on the server, run on all clients.
    private void RpcTogglePlayback ()
    {
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
            Debug.Log("Playback started.");
        }
        else
        {
            videoPlayer.Stop();
            Debug.Log("Playback stopped.");

        }
        Debug.Log("Called RpcTogglePlayback from server");
    }
}
