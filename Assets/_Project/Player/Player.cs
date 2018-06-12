using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

public class Player : MonoBehaviour 
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
        //       if (Input.GetKeyDown("space"))
        //       {
        //           displayManager.HideUI();
        //           videoManager.TogglePlayback();
        //       }

        if (Input.GetKeyDown("i"))
        {
            displayManager.ToggleUI();
        }
    }
}
