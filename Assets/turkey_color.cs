using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class turkey_color : MonoBehaviour {

	public Color next_color;
	public Color in_transition;
	public Color previous_color;
	private SpriteRenderer t;

	// Use this for initialization
	void Start () {
		t = GetComponent<SpriteRenderer>();
		in_transition = Color.red;
		previous_color = Color.red;
		next_color = Color.yellow;
	}
	
	// Update is called once per frame
	void Update () {
		in_transition = Color.Lerp(previous_color, next_color, Mathf.PingPong(Time.time, 1));
		t.color = in_transition;
	}
}