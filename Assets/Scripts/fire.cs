using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class fire : NetworkBehaviour {
   
     public  GameObject player;
    GameObject copy;
    Transform pos;
	// Use this for initialization
	void Start () {
        
      
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        copy.transform.parent = player.transform.parent;
    }
	
	// Update is called once per frame
	void Update () {
      
       if (!isLocalPlayer)
            return;
       
        copy.transform.position = player.transform.position;
        copy.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y, player.transform.eulerAngles.z + 180);
       
    }
    [Command]
    void CmdSetActiveFire(bool torf)
    {
       

        if (torf)
            copy.transform.GetComponent<SpriteRenderer>().enabled = true;
        else
            copy.transform.GetComponent<SpriteRenderer>().enabled = false;

    }
}
