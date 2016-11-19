using UnityEngine;
using System.Collections;

public class Level_Script : MonoBehaviour {

	public GameObject start_cannon;	

	public GameObject active_object;

	public GameObject camera;

	private Vector3 camera_offset;

	// Use this for initialization
	void Start () {
		active_object = start_cannon;
		camera_offset = camera.transform.position - start_cannon.transform.position;
		camera.transform.position = active_object.transform.position + camera_offset;
	}
	
	// Called when a projectile is launched
	// and when a new cannon is reached
	public void New_Location(GameObject new_object) {
		active_object = new_object;
	}

	// Update is called once per frame
	void Update () {
		camera.transform.position = active_object.transform.position + camera_offset;
		if (Input.GetKeyDown (KeyCode.R)) {
			active_object = start_cannon;	
			/*if(active object is projectile){
				remove the instance of the object
			}*/
		}

	}
}
