using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Next_Level_Button : MonoBehaviour {

    public string next_level;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void OnGUI() {
        if (GUILayout.Button("Next Level")) {
            if (Event.current.button == 0 || Event.current.button == 1) {
                SceneManager.LoadScene(next_level);
            }
        }
        if (GUILayout.Button("Quit")) {
            if (Event.current.button == 0 || Event.current.button == 1)
            {
                Application.Quit();
            }
        }
    }
}