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

    // Called on the client.
    public override void OnClientConnect (NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        Debug.LogFormat("{0} [Client] connected to {1}", Time.timeSinceLevelLoad, conn.address);
    }

    // Called on the server.
    public override void OnServerConnect (NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        Debug.LogFormat("{0} [Server] Client connected from {1}", Time.timeSinceLevelLoad, conn.address);
    }
}
      
