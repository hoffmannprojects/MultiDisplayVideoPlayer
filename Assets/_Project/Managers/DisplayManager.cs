using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

public class DisplayManager : MonoBehaviour 
{
    [SerializeField]
    private GameObject[] UIGameObjects;

    private bool uiIsVisible = true;

    // Use this for initialization
    private void Start ()
    {

    }

    #region PUBLIC METHODS
    public void ToggleUI ()
    {
        if (uiIsVisible)
        {
            HideUI();
        }
        else
        {
            ShowUI();
        }
    }

    public void HideUI ()
    {
        if (UIGameObjects.Length != 0)
        {
            foreach (var uiGameObject in UIGameObjects)
            {
                uiGameObject.SetActive(false);
            }

            uiIsVisible = false;
        }
    }

    public void ShowUI ()
    {
        if (UIGameObjects.Length != 0)
        {
            foreach (var uiGameObject in UIGameObjects)
            {
                uiGameObject.SetActive(true);
            }

            uiIsVisible = true;
        }
    } 
    #endregion
}
