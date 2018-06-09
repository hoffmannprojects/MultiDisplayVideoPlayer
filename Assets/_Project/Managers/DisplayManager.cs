using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.Video;

public class DisplayManager : MonoBehaviour
{
    [SerializeField]
    private int singleWidth = 1920;
    [SerializeField]
    private int height = 1080;
    [SerializeField]
    private bool enableCustomResolution = false;

    [SerializeField]
    private GameObject videoEnabledDebugText;
    [SerializeField]
    private VideoPlayer videoPlayer;

    // Use this for initialization
    void Start()
    {
        videoPlayer = FindObjectOfType<VideoPlayer>();
        Assert.IsNotNull(videoPlayer);
        Assert.IsNotNull(videoEnabledDebugText);

        if (enableCustomResolution)
        {
            Screen.SetResolution(singleWidth * 2, height, false);
            Display.displays[0].Activate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        videoEnabledDebugText.GetComponent<Text>().text = "isPlaying: " + videoPlayer.isPlaying;

    }
}
