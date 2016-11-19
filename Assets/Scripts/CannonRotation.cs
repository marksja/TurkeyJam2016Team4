using UnityEngine;
using System.Collections;

public class CannonRotation : MonoBehaviour
{
    private int mode = 1;
    public int barrel_length = 2;
	public bool active;
	public GameObject projectile_type;
    public GameObject level;
    public int power = 10;
    public float angle = 0;
    //public GUIStyle powerBar;

    //audio
    public AudioClip cannonshotSound;


    // Use this for initialization
    void Start()
    {

    }

    /*void OnGui() {
        public Texture2D tex;

        GUI.BeginGroup(new Rect(0, 0, power, 10);
        GUI.Box(new Rect(0, 0, 20, 10), tex, powerBar);
    }*/

    // Update is called once per frame
    void Update()
    {
        if (mode == 0)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector3 point = Camera.main.WorldToScreenPoint(transform.localPosition);
            mousePos.x -= point.x;
            mousePos.y -= point.y;

            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        if (mode == 1 && active)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                angle += 5;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                angle -= 5;
            }

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

			if (Input.GetKeyDown(KeyCode.UpArrow) && active)
			{
				if (power < 20)
				{
					power += 1;
				}
			}

			if (Input.GetKeyDown(KeyCode.DownArrow) && active)
			{
				if (power > 0)
				{
					power -= 1;
				}
			}

			if (Input.GetKey (KeyCode.Space) && active) {
                Vector3 barrel_vector = new Vector3 (Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
                barrel_vector.Normalize();

				GameObject projectile = Instantiate (projectile_type);
				projectile.SetActive (true);

				Rigidbody projectile_physics = projectile.GetComponent<Rigidbody> ();
                projectile.transform.position = transform.position + (barrel_length * barrel_vector);
				projectile_physics.velocity = barrel_vector * power;

				active = false;

                level.GetComponent<Level_Script>().New_Location(projectile);

                //AudioSource.PlayClipAtPoint(cannonshotSound, transform.position);
            }
        }
	        
    }

    void OnCollisionEnter(Collision collision){
        active = true;
        level.GetComponent<Level_Script>().New_Location(gameObject);
        Destroy(collision.collider.gameObject); 
    }
}
