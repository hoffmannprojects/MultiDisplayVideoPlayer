using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager
{

	// Use this for initialization
	private void Start () 
	{
		
	}
	
	// Update is called once per frame
	private void Update () 
	{
		
	}

    public override void OnClientConnect (NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        Debug.LogFormat("Client connected {0}", conn);
    }
}
