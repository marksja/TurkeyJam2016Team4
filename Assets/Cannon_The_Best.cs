using UnityEngine;
using System.Collections;

public class Cannon_The_Best : MonoBehaviour {

    // private int mode = 1;
    // private float rotateIncrement = 50f;
    public int barrel_length = 2;
    // public bool active = true;
    public GameObject projectile_type;
    public float power = 7f;
    public float angle = 0f;
    public GameObject cannon;
    public float x = 7, y = 7, z = 0;
    private int totalTime = 84;
    public int timer = 0;

    

    // Use this for initialization
    void Awake () {
	    angle = cannon.transform.localEulerAngles.z;
        timer = (int)(Random.value * 60) + 85;

    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
	        Vector3 barrel_vector = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
	        barrel_vector.Normalize();

	        GameObject projectile = Instantiate(projectile_type);
	        projectile.SetActive(true);
	        //projectile.transform.localScale = new Vector3(x, y, z);
	        projectile.transform.localPosition = new Vector3(cannon.transform.localPosition.x, cannon.transform.localPosition.y, cannon.transform.localPosition.z);

	        Rigidbody projectile_physics = projectile.GetComponent<Rigidbody>();
	        projectile.transform.position = transform.position + (barrel_length * barrel_vector);
	        projectile_physics.velocity = barrel_vector * power;

	        // active = false;

	        Destroy(projectile, 1.8F);
    	}
    }
}
