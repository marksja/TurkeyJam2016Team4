using UnityEngine;
using System.Collections;

public class Turkey_script : MonoBehaviour {
    private float angle = 0;
    private Level_Script l_s;

    public AudioClip HitWallSound;
    public GameObject level;

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
	void OnCollisionEnter(Collision collision){
        AudioSource.PlayClipAtPoint(HitWallSound, transform.position);
    }

    public void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Spike")) {
            l_s = level.GetComponent<Level_Script>();
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
