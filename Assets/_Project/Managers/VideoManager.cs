using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;
using UnityEngine.Video;

public class VideoManager : NetworkBehaviour
{
    [SerializeField]
    private string videoUrl = "file.mov";
    private VideoPlayer videoPlayer;

    // Use this for initialization
    void Start()
    {
        videoPlayer = Camera.main.GetComponent<VideoPlayer>();
        Assert.IsNotNull(videoPlayer);

        // Platform specific file paths.
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            // Windows code.
            videoPlayer.url = Application.dataPath + "/../" + videoUrl;
        }
        else
        {
            // Mac code.
            videoPlayer.url = Application.dataPath + "/../../" + videoUrl;
        }
        Debug.LogErrorFormat("videoUrl set to: {0}", videoPlayer.url);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown("space"))
        {
            CmdTogglePlayback();
        }
    }

    // Called from the client, run on the server.
    [Command]
    public void CmdTogglePlayback()
    {
        Debug.Log("Called CmdTogglePlayback from client.");
        RpcTogglePlayback();
    }

    // Called on the server, run on all clients.
    [ClientRpc]
    private void RpcTogglePlayback()
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
