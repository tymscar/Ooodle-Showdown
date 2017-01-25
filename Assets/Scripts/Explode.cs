using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
    Animator animatorr;
    // Use this for initialization
    void Start () {
        animatorr = GetComponent<Animator>();
        animatorr.Play("Death");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
