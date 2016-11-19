using UnityEngine;
using System.Collections;

public class login : MonoBehaviour {

    public AudioClip TurkeyTreeSound;
    public float time;
    public int twelve = 12;

    // Use this for initialization
    void Start () {
        InvokeRepeating("PlayAudio", 0.0f, 12.0f);
    }
	
    void PlayAudio()
    {
        AudioSource.PlayClipAtPoint(TurkeyTreeSound, transform.position);
    }

	// Update is called once per frame
	void Update () {
    }
}
