using UnityEngine;
using System.Collections;

public class black_hole : MonoBehaviour {

	public float magnitude;
	public GameObject temp;

	private Vector3 direction_to_player;

	// Use this for initialization
	void Start () {
		magnitude = 300;
		Physics.gravity = new Vector3(0, -9.8F, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		direction_to_player = transform.position - other.gameObject.transform.position;
		direction_to_player.Normalize();
		Physics.gravity = direction_to_player * magnitude;
		Debug.Log("Hello World");
	}
	void OnTriggerStay(Collider other){
		direction_to_player = transform.position - other.gameObject.transform.position;
		direction_to_player.Normalize();
		Physics.gravity = direction_to_player * magnitude;
		Debug.Log("Hello World");
	}
	void OnTriggerExit(Collider other){
		Physics.gravity = new Vector3(0, -9.8F, 0);
		Debug.Log("Noope");
	}
}
