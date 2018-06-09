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

    public override void OnStartClient (NetworkClient client)
    {
        base.OnStartClient(client);
        Debug.LogFormat("{0} Client start requested {1}", Time.timeSinceLevelLoad, client);
    }

    public override void OnClientConnect (NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        Debug.LogFormat("{0} Client connected to {1}", Time.timeSinceLevelLoad, conn.address);
    }
}
      
