using UnityEngine;
using System.Collections;

public class Level_Script : MonoBehaviour {

	public GameObject start_cannon;	

	public GameObject active_object;

	public GameObject camera;

	private Vector3 camera_offset;

    public Texture bar;

	// Use this for initialization
	void Start () {
		active_object = start_cannon;
        camera_offset = new Vector3(0, 0, -10);
        // camera.transform.position - start_cannon.transform.position;
		camera.transform.position = active_object.transform.position + camera_offset;
		//start_cannon.GetComponent<CannonRotation>().is_start = true;
	}
	
	// Called when a projectile is launched
	// and when a new cannon is reached
	public void New_Location(GameObject new_object) {
		active_object = new_object;
	}

    public void OnGUI()
    {
        if (active_object.name == "Cannon 2.0")
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 32 - camera_offset.x, (Screen.height / 2) + 30 - camera_offset.y, (active_object.GetComponent<CannonRotation>().power - 4) * 2, 10), bar);
        }
    }

    // Update is called once per frame
    void Update () {
		camera.transform.position = active_object.transform.position + camera_offset;
		if (Input.GetKeyDown (KeyCode.R)) {
			//Use scale to determine 
			if(active_object.name == "Cannon 2.0"){
				active_object.GetComponent<CannonRotation>().active = false;
			}
			else if(active_object.name == "Goal"){
				//Don't reset since we're at the goal
			}
			else{
				Destroy(active_object);
			}
			active_object = start_cannon;
			start_cannon.GetComponent<CannonRotation>().active = true;
			/*if(active object is projectile){
				remove the instance of the object
			}*/
		}

	}
}
