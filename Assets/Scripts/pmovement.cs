using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class pmovement : NetworkBehaviour
{
    [SyncVar]
    public ParticleSystem p;

    public GameObject bpos;
    public GameObject firepos;
    static public bool inside = true;
    Vector3 temp, temp1;
    public float f_RotSpeed = 0.25f;
  
    Camera ccamera;
    GameObject b;//bullet
    bool move1 = false;
    bool cooldown = false;
    [SyncVar]
    public int health = 100;
    //values that will be set in the Inspector

    public float speedofbullet = 25;
    public float cooldowntime;
    //values for internal use
    [SyncVar]
    public  float speed;
    Vector3 lastPos;
    Vector3 forcam;
    bool moving = false;//for mooving bulletts
    bool f = false;//for cooldown
     GameObject Fire;

    GameObject ttemp;
    // Use this for initialization
    void Start()
    {
        p.Play();
        Fire= (GameObject)Resources.Load("Fire");
       
        //  
        //NetworkServer.Spawn(Fire);
       
        gameObject.transform.name = "Player" + ID.id;
        ID.id++;
      
        gameObject.SetActive(true);
      
        ccamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        b = (GameObject)Resources.Load("bulletPP");
      
    }


    // Update is called once per frame
    void Update()
    {
       
        if (!isLocalPlayer)
            return;
       

        if (health <= 0)
            Destroy(gameObject);

        forcam = transform.position;
        temp = Input.mousePosition;
        temp1 = Camera.main.ScreenToWorldPoint(temp);
        lastPos = transform.position;

        if (temp1.x > -40 && temp1.x < 42.5 && temp1.y < 22 && temp1.y > -24)
        {


           

            float move = f_RotSpeed * Time.deltaTime;
          
            transform.position = Vector3.MoveTowards(transform.position, temp1, move);



            //rotat
            transform.rotation = Quaternion.LookRotation(Vector3.forward, temp1 - transform.position);

          

            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        else
        {
            // fire.SetActive(false);

        }
        speed = (transform.position - lastPos).magnitude;
       
       // CmdSetActiveFire(speed);
        
          
        ccamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        ccamera.transform.position = forcam;
        ccamera.transform.position = new Vector3(forcam.x, forcam.y, -10f);
        if (Input.GetKeyDown(KeyCode.Space))
        {





           
            CmdFire();

        }

        if (speed < 0.14f)
            p.Stop();
        else
            if (!p.isPlaying)
            p.Play();






      //  Thrusters();
    }
   
   


    [Command]
    void CmdFire()
    {
        if (f == false)
        {
            if (cooldown == true)
                return;

            GameObject bu = (GameObject)Instantiate(b, Vector3.forward, transform.rotation);
            bu.transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 90);
            bu.transform.parent = transform;

            bu.transform.position = bpos.transform.position;
            bu.GetComponent<SpriteRenderer>().enabled = false;
            bu.name = gameObject.name + "b";
            bu.transform.GetComponent<Collider2D>().isTrigger = true;
            bu.transform.GetComponent<SpriteRenderer>().enabled = true;
            cooldown = true;
            f = false;
            bu.transform.parent = null;
            bu.GetComponent<Rigidbody2D>().velocity = bu.transform.right * speedofbullet;

            NetworkServer.Spawn(bu);
            StartCoroutine(Wait());
            Destroy(bu, 3.25f);
        }


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!isServer)
            return;
        if (move1 == false)
        {
            move1 = true;
            return;
        }
        if (col.name == transform.name + "b")
            return;
        else {
            health -= 50;
         
        }
    }
    public override void OnStartLocalPlayer()
    {

        GetComponent<SpriteRenderer>().color = Color.white;


    }

    IEnumerator Wait()
    {

        yield return new WaitForSeconds(cooldowntime);
        cooldown = false;
    }
}
