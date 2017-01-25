// This script spawns the pings when spacebar is pressed

using UnityEngine;
using System.Collections;

public class Ping : MonoBehaviour
{
    PlayerMove moveScript;
    public GameObject pingPrefab;
    public GameObject pingCollider;
    private GameObject tempGameObject;
	
    void Start()
    {
        moveScript = GetComponent<PlayerMove>();
    }

	void Update ()
    {
        SpawnPing();
    }

    void SpawnPing()
    {
        if (Input.GetKeyDown("space") && moveScript.playerNo == 1)
        {
            tempGameObject = Instantiate(pingCollider, this.transform) as GameObject;
            tempGameObject.transform.position = this.transform.position;
            tempGameObject.transform.position = new Vector3(tempGameObject.transform.position.x, tempGameObject.transform.position.y + 1, tempGameObject.transform.position.z);
            tempGameObject.transform.parent = null;
            tempGameObject = Instantiate(pingPrefab, this.transform) as GameObject;
            tempGameObject.transform.position = this.transform.position;
            tempGameObject.transform.position = new Vector3(tempGameObject.transform.position.x, tempGameObject.transform.position.y + 1, tempGameObject.transform.position.z);
            tempGameObject.transform.parent = null;
        }
        if (Input.GetButtonDown("Fire1") && moveScript.playerNo == 2)
        {
            tempGameObject = Instantiate(pingCollider, this.transform) as GameObject;
            tempGameObject.transform.position = this.transform.position;
            tempGameObject.transform.position = new Vector3(tempGameObject.transform.position.x, tempGameObject.transform.position.y + 1, tempGameObject.transform.position.z);
            tempGameObject.transform.parent = null;
            tempGameObject = Instantiate(pingPrefab, this.transform) as GameObject;
            tempGameObject.transform.position = this.transform.position;
            tempGameObject.transform.position = new Vector3(tempGameObject.transform.position.x, tempGameObject.transform.position.y + 1, tempGameObject.transform.position.z);
            tempGameObject.transform.parent = null;
        }
    }
}
