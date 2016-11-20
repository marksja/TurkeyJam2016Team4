using UnityEngine;
using System.Collections;

public class Turkey_script : MonoBehaviour {
    private float angle = 0;

    public AudioClip HitWallSound;
    public AudioClip PortalSound;
    public bool transported = false;

    public 

    // Use this for initialization
    void Start () {
	
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
        else{
            AudioSource.PlayClipAtPoint(HitWallSound, transform.position);
        }
        rig.velocity = ori_vel;
    }
}
