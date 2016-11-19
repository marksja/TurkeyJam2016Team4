using UnityEngine;
using System.Collections;

public class TurkeyRotate_Slow : MonoBehaviour {
    // Use this for initialization
    void Awake() {
  
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0, 0, 2);
	}
}
