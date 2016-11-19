using UnityEngine;
using System.Collections;

public class Turkey_script : MonoBehaviour {
    public AudioClip HitWallSound;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// When the turkey collides with the object
	void OnCollisionEnter(Collision collision){
        //AudioSource.PlayClipAtPoint(HitWallSound, transform.position);
    }
}
