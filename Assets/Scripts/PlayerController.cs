using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public GameObject Ping;
    public GameObject spawn;
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 4.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 12.0f;

        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
    }

    [Command]
    void CmdFire()
    {
        // Create the ping from the Bullet Prefab
        var ping = (GameObject)Instantiate(Ping,spawn.transform.position,spawn.transform.rotation); 

        // Spawn the ping on the Clients
        NetworkServer.Spawn(ping);

        // Destroy the ping after 2 seconds
        Destroy(ping, 5.0f);
    }


    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}