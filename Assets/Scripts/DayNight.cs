using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var x = Time.deltaTime * 5.0f;
        transform.Rotate(x, 0, 0);

    }
}
