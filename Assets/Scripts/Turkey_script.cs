using UnityEngine;
using System.Collections;

public class Turkey_script : MonoBehaviour {
    private float angle = 0;

    public AudioClip HitWallSound;
    public AudioClip PortalSound;
    public bool transported = false;

    private GameObject level;
    private Level_Script l_s;

    private Rigidbody rig; 

    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody>();
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
        rig = GetComponent<Rigidbody>();
        Vector3 ori_vel = rig.velocity;
        string name = collision.name;
        int end_letter = 0;
        string main_bit = name;
        if(name.Length > 6){
            end_letter = name[6] - 48;
            main_bit = name.Substring(0,6);
        }
        Debug.Log(main_bit);
        Debug.Log(end_letter);
        Debug.Log(name);
        if (main_bit == "Portal" && end_letter % 2 == 0 && !transported)
        {
            Debug.Log(main_bit);
            Debug.Log(end_letter);
            GameObject portal = GameObject.Find("Portal" + (end_letter+1));
            if (ori_vel.x >= 1)
            {
                gameObject.transform.position = portal.transform.position + new Vector3(size.x, 0, 0);
            }
            else if (ori_vel.x <= -1)
            {
                gameObject.transform.position = portal.transform.position + new Vector3(-size.x, 0, 0);
            }
            else{
                gameObject.transform.position = portal.transform.position;
            }
            transported = true;
            AudioSource.PlayClipAtPoint(PortalSound, transform.position);
        }

        else if(main_bit == "Portal" && end_letter % 2 == 1 && !transported)
        {
            Debug.Log(main_bit);
            Debug.Log(end_letter);
            GameObject portal = GameObject.Find("Portal" + (end_letter-1));
            if (ori_vel.x >= 1)
            {
                gameObject.transform.position = portal.transform.position + new Vector3(size.x, 0, 0);
            }
            else if (ori_vel.x <= -1)
            {
                gameObject.transform.position = portal.transform.position + new Vector3(-size.x, 0, 0);
            }
            else{
                gameObject.transform.position = portal.transform.position;
            }
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
    void OnTriggerExit(Collider collider){
        //transported = false;
    }

    void OnCollisionEnter(Collision collision){
        if (!collision.gameObject.CompareTag("Bouncy"))
        {
            //rig.velocity = Vector3.zero;
        }
    }
}
