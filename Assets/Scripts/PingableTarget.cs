// This script stays on anything that can be pinged. Be it a player or an object

using UnityEngine;
using System.Collections;

public class PingableTarget : MonoBehaviour
{
    public GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "wave")
        {

            StartCoroutine(beenHit());
        }
    }

    IEnumerator beenHit()
    {
        this.GetComponent<SpriteRenderer>().color = gameController.PlayerColour[GetComponent<PlayerMove>().playerNo];
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<SpriteRenderer>().color = gameController.whitem;
    }
}
