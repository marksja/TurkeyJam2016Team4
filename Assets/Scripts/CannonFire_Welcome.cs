using UnityEngine;
using System.Collections;

public class CannonFire_Welcome : MonoBehaviour {

    // private int mode = 1;
    // private float rotateIncrement = 50f;
    public int barrel_length = 2;
    public bool active;
    public GameObject projectile_type;
    // public GameObject level;
    public float power = 20;
    public float angle = 0f;
    public GameObject cannon;

    

    // Use this for initialization
    void Awake () {
	    angle = cannon.transform.localEulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space) && active)
        {
            Vector3 barrel_vector = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
            barrel_vector.Normalize();

            GameObject projectile = Instantiate(projectile_type);
            projectile.SetActive(true);

            Rigidbody projectile_physics = projectile.GetComponent<Rigidbody>();
            projectile.transform.position = transform.position + (barrel_length * barrel_vector);
            projectile_physics.velocity = barrel_vector * power;

            active = false;

            // level.GetComponent<Level_Script>().New_Location(projectile);

            //AudioSource.PlayClipAtPoint(cannonshotSound, transform.position);
        }

    }
}
