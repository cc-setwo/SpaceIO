using UnityEngine;
using System.Collections;

public class Cursorpos : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = Input.mousePosition;
        temp.z = 0;
      Vector3  temp1 = Camera.main.ScreenToWorldPoint(temp);
        temp1.z = 0;
        if (temp1.x > -20 && temp1.x < 20 && temp1.y < 20 && temp1.y > -20)
        {



            transform.position = Camera.main.ScreenToWorldPoint(temp);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            pmovement.inside = true;
        }
        else
            pmovement.inside = false;
        
    }
}
