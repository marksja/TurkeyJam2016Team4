using UnityEngine;
using System.Collections;

public class Turkey_script : MonoBehaviour {
    private float angle = 0;

    public AudioClip HitWallSound;
    public AudioClip PortalSound;
    public bool transported = false;

    private GameObject level;
    private Level_Script l_s;

    public 

    // Use this for initialization
    void Start () {
        level = GameObject.Find("Level");
	}
	
	// Update is called once per frame
	void Update () {
        angle += 10f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

	// When the turkey collides with the object
	void OnTriggerEnter(Collider collision){
        Vector3 size = collision.bounds.size;
        Rigidbody rig = GetComponent<Rigidbody>();
        Vector3 ori_vel = rig.velocity;
        if (collision.name == "Portal0" && !transported)
        {
            if(ori_vel.x >= 0)
            {
                gameObject.transform.position = GameObject.Find("Portal1").transform.position + new Vector3(size.x, 0, 0);
            }
            else
            {
                gameObject.transform.position = GameObject.Find("Portal1").transform.position + new Vector3(-size.x, 0, 0);
            }
            transported = true;
            AudioSource.PlayClipAtPoint(PortalSound, transform.position);
        }

        else if(collision.name == "Portal1" && !transported)
        {
            if (ori_vel.x >= 0)
            {
                gameObject.transform.position = GameObject.Find("Portal1").transform.position + new Vector3(size.x, 0, 0);
            }
            else
            {
                gameObject.transform.position = GameObject.Find("Portal1").transform.position + new Vector3(-size.x, 0, 0);
            }
            gameObject.transform.position = GameObject.Find("Portal0").transform.position;
            transported = true;
            AudioSource.PlayClipAtPoint(PortalSound, transform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(HitWallSound, transform.position);
        }
        rig.velocity = ori_vel;

        if (collision.CompareTag("Spike"))
        {
            l_s = level.GetComponent<Level_Script>();
           
            //Use scale to determine 
            if (l_s.active_object.name == "Cannon 2.0")
            {
                l_s.active_object.GetComponent<CannonRotation>().active = false;
            }
            else if (l_s.active_object.name == "Goal")
            {
                //Don't reset since we're at the goal
            }
            else
            {
                Destroy(l_s.active_object);
            }
            l_s.active_object = l_s.start_cannon;
            l_s.start_cannon.GetComponent<CannonRotation>().active = true;
         }
    }
}
