using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager
{
    private DisplayManager displayManager;

	// Use this for initialization
	private void Start () 
	{
        displayManager = FindObjectOfType<DisplayManager>();
        Assert.IsNotNull(displayManager);
	}

    // Called on the client.
    public override void OnClientConnect (NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        Debug.LogFormat("{0} [Client] connected to {1}", Time.timeSinceLevelLoad, conn.address);

        displayManager.ShowUI();
    }

    // Called on the server.
    public override void OnServerConnect (NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        Debug.LogFormat("{0} [Server] Client connected from {1}", Time.timeSinceLevelLoad, conn.address);
    }
}
      
