﻿using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SFB;

[RequireComponent(typeof(Button))]
public class OpenFileDialogue : MonoBehaviour, IPointerDownHandler
{
    public string Title = "";
    public string FileName = "";
    public string Directory = "";
    public string Extension = "";
    public bool Multiselect = false;
    [SerializeField]
    private int _targetDisplay = 1;

    [SerializeField]
    private VideoManager _videoManager;

#if UNITY_WEBGL && !UNITY_EDITOR
    //
    // WebGL
    //
    [DllImport("__Internal")]
    private static extern void UploadFile(string id);

    public void OnPointerDown(PointerEventData eventData) {
        UploadFile(gameObject.name);
    }

    // Called from browser
    public void OnFileUploaded(string url) {
        StartCoroutine(OutputRoutine(url));
    }
#else
    //
    // Standalone platforms & editor
    //
    public void OnPointerDown (PointerEventData eventData) { }

    void Start ()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        Assert.IsNotNull(_videoManager);
    }

    private void OnClick ()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel(Title, Directory, Extension, Multiselect);
        if (paths.Length > 0)
        {
            StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
        }
    }
#endif

    private IEnumerator OutputRoutine (string url)
    {
        Debug.Log("URL: " + url);
        var loader = new WWW(url);
        yield return loader;
        //output.texture = loader.texture;

        _videoManager.VideoFilePaths[_targetDisplay] = loader.ToString();
    }
}