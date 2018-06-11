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
    private string fileName = "file.mov";
    [SerializeField]
    private Text debugText;
    private VideoPlayer videoPlayer;

    // Use this for initialization
    void Start()
    {
        videoPlayer = Camera.main.GetComponent<VideoPlayer>();
        Assert.IsNotNull(videoPlayer);

        Assert.IsNotNull(debugText);

        string filePath = null;
        // Platform specific file paths.
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            // Windows code.
            filePath = Application.dataPath + "/../" + fileName;
        }
        else
        {
            // Mac code.
            filePath = Application.dataPath + "/../../" + fileName;
        }
        videoPlayer.url = filePath;
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += Prepared;

        debugText.enabled = true;
        debugText.text = "Preparing video for playback.";
    }

    private void Prepared (VideoPlayer vPlayer)
    {
        debugText.text = "Video is ready for playback.";
        debugText.color = Color.green;
    }

    #region PUBLIC METHODS
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
    #endregion
}
