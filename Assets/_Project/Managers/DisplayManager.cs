using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

public class DisplayManager : MonoBehaviour 
{
    [SerializeField]
    private GameObject[] _uiGameObjects;
    private NetworkManagerHUD _networkManagerHud;

    private bool uiIsVisible = true;

    // Use this for initialization
    private void Start ()
    {
        _networkManagerHud = FindObjectOfType<NetworkManagerHUD>();
    }

    #region PUBLIC METHODS
    public void ToggleUI ()
    {
        if (uiIsVisible)
        {
            HideUI();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            ShowUI();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void HideUI ()
    {
        if (_uiGameObjects.Length != 0)
        {
            foreach (var uiGameObject in _uiGameObjects)
            {
                uiGameObject.SetActive(false);
                _networkManagerHud.showGUI = false;
            }

            uiIsVisible = false;
        }
    }

    public void ShowUI ()
    {
        if (_uiGameObjects.Length != 0)
        {
            foreach (var uiGameObject in _uiGameObjects)
            {
                uiGameObject.SetActive(true);
                _networkManagerHud.showGUI = true;
            }

            uiIsVisible = true;
        }
    } 
    #endregion
}
