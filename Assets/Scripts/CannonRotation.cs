using UnityEngine;
using System.Collections;

public class CannonRotation : MonoBehaviour
{
    private int mode = 1;
    private float rotateIncrement = 50f;
    private float powerIncrement = 10f;
    public int barrel_length = 2;
	public bool active;
	public GameObject projectile_type;
    public GameObject level;
    public float power = 20;
    public float angle = 0;
    public Texture bar;
    
    private Level_Script l_s;

    //audio
    public AudioClip cannonshotSound;


    // Use this for initialization
    void Start()
    {
        level = GameObject.Find("Level");
        l_s = level.GetComponent<Level_Script>();
    }

    public void OnGUI()
    {
        if (active)
        {
            GUI.DrawTexture(new Rect(Camera.main.WorldToScreenPoint(transform.position).x - 25, Camera.main.WorldToScreenPoint(transform.position).y + 20, (power - 4) * 2, 10), bar);
        }

    }

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

            if (Input.GetKeyDown(KeyCode.UpArrow) && active)
            {
                if (power < 30)
                {
                    power += 2f;
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && active)
            {
                if (power > 5)
                {
                    power -= 2f;
                }
            }

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

                l_s.New_Location(projectile);

                //AudioSource.PlayClipAtPoint(cannonshotSound, transform.position);
            }
        }



        if (mode == 1 && active)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                angle += rotateIncrement * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                angle -= rotateIncrement * Time.deltaTime;
            }

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

			if (Input.GetKey(KeyCode.UpArrow) && active)
			{
				if (power < 30)
				{
					power += powerIncrement * Time.deltaTime;
				}
			}

			if (Input.GetKey(KeyCode.DownArrow) && active)
			{
				if (power > 5)
				{
					power -= powerIncrement * Time.deltaTime;
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

                l_s.New_Location(projectile);

                //AudioSource.PlayClipAtPoint(cannonshotSound, transform.position);
            }
        }
	        
    }

    void OnCollisionEnter(Collision collision){
        active = true;
        l_s.New_Location(gameObject);
        Destroy(collision.collider.gameObject); 
    }
}
