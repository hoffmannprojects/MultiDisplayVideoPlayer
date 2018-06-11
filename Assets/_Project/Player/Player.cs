using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

public class Player : NetworkBehaviour 
{
    VideoManager videoManager;

	// Use this for initialization
	private void Start () 
	{
        videoManager = FindObjectOfType<VideoManager>();
        Assert.IsNotNull(videoManager);
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
            videoManager.CmdTogglePlayback();
        }
    }
}
