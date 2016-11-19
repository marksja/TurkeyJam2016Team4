using UnityEngine;
using System.Collections;

public class TurkeyRotate_Slow : MonoBehaviour {
    private GameObject turkey;
    // Use this for initialization
    void Awake() {
        turkey = GameObject.Find("Turkey");
    }
	
	// Update is called once per frame
	void Update () {
        turkey.transform.Rotate(0, 0, 2);
	}
}
