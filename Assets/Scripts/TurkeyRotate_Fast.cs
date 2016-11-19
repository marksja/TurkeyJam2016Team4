using UnityEngine;
using System.Collections;

public class TurkeyRotate_Fast : MonoBehaviour
{
    // Use this for initialization
    void Awake() {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, 10);
    }
}
