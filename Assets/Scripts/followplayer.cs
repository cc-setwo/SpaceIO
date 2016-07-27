using UnityEngine;
using System.Collections;

public class followplayer : MonoBehaviour {
  public  GameObject g;
	// Use this for initialization
	void Start () {
    
     
	}
	
	// Update is called once per frame
	void Update () {
        
        g = GameObject.FindGameObjectWithTag("Player");
       
	}
}
