using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    // Use this for initialization
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.url = "Assets/file.mp4";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
