﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class q : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;
    }
}
