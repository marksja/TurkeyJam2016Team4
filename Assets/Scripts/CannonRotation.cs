using UnityEngine;
using System.Collections;

public class CannonRotation : MonoBehaviour
{
    private int mode = 1;
	public bool active;
	public GameObject projectile_type;
    public static int power = 10;
    public float angle = 0;
    //public GUIStyle powerBar;

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
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                angle += 5;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                angle -= 5;
            }

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

			if (Input.GetKey(KeyCode.D) && active)
			{
				if (power < 20)
				{
					power += 1;
				}
			}

			if (Input.GetKey(KeyCode.A) && active)
			{
				if (power > 0)
				{
					power -= 1;
				}
			}

			if (Input.GetKey (KeyCode.Space) && active) {
				GameObject projectile = Instantiate (projectile_type);
				Rigidbody projectile_physics = projectile.GetComponent<Rigidbody> ();
				projectile_physics
			}
        }
	        
    }
}
