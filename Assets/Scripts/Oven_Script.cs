using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Oven_Script : MonoBehaviour {

	public int num_cannons;
	public string next_level;
	public float time;
    public GameObject winScreen;

    public AudioClip TurkeySound;

    // Use this for initialization
    void Start () {
        //winScreen.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(next_level);
        }
    }

	void OnCollisionEnter(Collision collision){
        //AudioSource.PlayClipAtPoint(TurkeySound, transform.position);
        
        GameObject level = GameObject.Find("Level");
		level.GetComponent<Level_Script>().New_Location(gameObject);
		Destroy(collision.collider.gameObject);
        //Go to victory screen
        //Calculate score or whatever

        //Display Win Screen
        winScreen.SetActive(true);
		//SceneManager.LoadScene(next_level);

	}
}
