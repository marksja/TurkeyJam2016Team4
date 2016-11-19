using UnityEngine;
using System.Collections;

public class CannonRotation : MonoBehaviour {
    private int mode = 1;
    float angle = 0;

    // Use this for initialization
    void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
        if (mode == 0) {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector3 point = Camera.main.WorldToScreenPoint(transform.localPosition);
            mousePos.x -= point.x;
            mousePos.y -= point.y;

            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        if (mode == 1) {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                angle += 5;
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                angle -= 5;
            }

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
