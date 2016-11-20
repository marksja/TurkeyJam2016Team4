using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Play_button : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick(string level_name){
		if(level_name == "Quit"){
			Application.Quit();
		}
		SceneManager.LoadScene(level_name);
	}
}
