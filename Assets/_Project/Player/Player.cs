using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    private VideoManager videoManager;
    private DisplayManager displayManager;

    // Use this for initialization
    private void Start ()
    {
        videoManager = FindObjectOfType<VideoManager>();
        Assert.IsNotNull(videoManager);

        displayManager = FindObjectOfType<DisplayManager>();
        Assert.IsNotNull(displayManager);
    }

    // Update is called once per frame
    private void Update ()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown("space"))
        {
            CmdTogglePlayback();
            displayManager.ToggleUI();
        }

        if (Input.GetKeyDown("i"))
        {
            displayManager.ToggleUI();
        }
    }

    // Called from the client, run on the server.
    [Command]
    public void CmdTogglePlayback ()
    {
        RpcTogglePlayback();
    }

    // Called on the server, run on all clients.
    [ClientRpc]
    private void RpcTogglePlayback ()
    {
        videoManager.TogglePlayback();
    }
}