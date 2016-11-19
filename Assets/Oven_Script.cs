using UnityEngine;
using System.Collections;

public class Oven_Script : MonoBehaviour {

	public int num_cannons;

	public float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
	}

	void OnCollisionEnter(Collision collision){
		GameObject level = GameObject.Find("Level");
		level.GetComponent<Level_Script>().New_Location(gameObject);
		Destroy(collision.collider.gameObject); 
		//Go to victory screen
		//Calculate score or whatever
	}
}
