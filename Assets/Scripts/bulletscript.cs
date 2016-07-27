using UnityEngine;
using System.Collections;


public class bulletscript : MonoBehaviour
{

    public float speed;
  public static bool f = true;



    GameObject g;
    public int damage;
    // Use this for initialization
    void Start()
    {
        transform.name = transform.parent.name;
        g = gameObject.transform.parent.gameObject;
        transform.GetComponent<Collider2D>().isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        

      

    }

  
    void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("123");
    }

}
