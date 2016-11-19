using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Next_Level_Button : MonoBehaviour {

    public string next_level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(next_level);
        }
	}
}
