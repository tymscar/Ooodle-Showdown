//This script resides on the colider. It scales it

using UnityEngine;
using System.Collections;

public class PingCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(increaseSize());
	}

    IEnumerator increaseSize()
    {
        while (true)
        {
            SphereCollider sphereCollider = this.GetComponent<SphereCollider>();
            sphereCollider.radius += 1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
