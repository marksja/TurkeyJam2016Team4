using UnityEngine;
using System.Collections;

public class Turkey_script : MonoBehaviour {
    private float angle = 0;

    public AudioClip HitWallSound;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        angle += 10f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

	// When the turkey collides with the object
	void OnCollisionEnter(Collision collision){
        AudioSource.PlayClipAtPoint(HitWallSound, transform.position);
    }
}
