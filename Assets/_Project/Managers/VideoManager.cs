using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
//using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField]
    private string file1Name = "file1.mov";
    [SerializeField]
    private string file2Name = "file2.mov";
    [SerializeField]
    private Text debugText;
    private VideoPlayer videoPlayer1;
    private VideoPlayer videoPlayer2;
    private DisplayManager displayManager;

    private bool playbackIsStarted = false;
    private double maxTimingError = 0d;
    private long framesDropped = 0;
    
    // Use this for initialization
    void Start ()
    {
        InitializeReferences();

        SetVideoUrls();

        // External reference clock the VideoPlayer observes to detect and correct drift.
        videoPlayer1.timeReference = VideoTimeReference.InternalTime;
        videoPlayer2.timeReference = videoPlayer1.timeReference;

        Debug.Log("video1 timeReference: " + videoPlayer1.timeReference);
        Debug.Log("video2 timeReference: " + videoPlayer2.timeReference);

        videoPlayer1.Prepare();
        videoPlayer2.Prepare();

        videoPlayer1.prepareCompleted += Prepared;

        debugText.enabled = true;
        debugText.text = "Preparing video for playback.";

    }

    private void InitializeReferences ()
    {
        videoPlayer1 = Camera.main.GetComponent<VideoPlayer>();
        Assert.IsNotNull(videoPlayer1);

        videoPlayer2 = GameObject.FindGameObjectWithTag("Display2Camera").GetComponent<VideoPlayer>();
        Assert.IsNotNull(videoPlayer2);

        displayManager = FindObjectOfType<DisplayManager>();
        Assert.IsNotNull(displayManager);

        Assert.IsNotNull(debugText);
    }

    private void SetVideoUrls ()
    {
        string file1Path = null;
        string file2Path = null;
        // Platform specific file paths.
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            // Windows code.
            file1Path = Application.dataPath + "/../" + file1Name;
            file2Path = Application.dataPath + "/../" + file2Name;
        }
        else
        {
            // Mac code.
            file1Path = Application.dataPath + "/../../" + file1Name;
            file2Path = Application.dataPath + "/../../" + file2Name;
        }

        videoPlayer1.url = file1Path;
        videoPlayer2.url = file2Path;
    }

    private void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            TogglePlayback();
        }

        if (playbackIsStarted)
        {
            // Reference time of the external clock the VideoPlayer uses to correct its drift.
            // Only relevant when VideoPlayer.timeReference is set to VideoTimeReference.ExternalTime.
            //videoPlayer2.externalReferenceTime = videoPlayer1.time;

            long frameError = System.Math.Abs(videoPlayer1.frame - videoPlayer2.frame);
            Debug.LogFormat("frameError: {0}", frameError);

            double timingError = System.Math.Abs(videoPlayer1.time - videoPlayer2.time);
            Debug.LogFormat("timeError: {0}", timingError);

            if (timingError > maxTimingError)
            {
                maxTimingError = timingError;
            }

            if (frameError > 0)
            {
                framesDropped += frameError;
            }
        }
    }

    private void Prepared (VideoPlayer vPlayer)
    {
        debugText.text = "Video is ready for playback.";
        debugText.color = Color.green;
    }

    #region PUBLIC METHODS
    public void TogglePlayback ()
    {
        if (!videoPlayer1.isPlaying)
        {
            displayManager.HideUI();

            videoPlayer1.Play();
            videoPlayer2.Play();
        }
        else
        {
            videoPlayer1.Stop();
            videoPlayer2.Stop();

            displayManager.ShowUI();

            Debug.LogFormat("maxTimingError: {0}", maxTimingError);

            debugText.text += "\n max. Timing Error: " + maxTimingError + "\n Frames dropped: " + framesDropped;
        }
        playbackIsStarted = !playbackIsStarted;
    } 
    #endregion
}
