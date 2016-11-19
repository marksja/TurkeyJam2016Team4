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
}
