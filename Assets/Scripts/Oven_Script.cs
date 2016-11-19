﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Oven_Script : MonoBehaviour {

	public int num_cannons;
	public string next_level;
	public float time;
    public Canvas winScreen;

	// Use this for initialization
	void Awake () {
        winScreen.enabled = false;
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

        //Display Win Screen
        winScreen.enabled = true;
		//SceneManager.LoadScene(next_level);

	}
}
