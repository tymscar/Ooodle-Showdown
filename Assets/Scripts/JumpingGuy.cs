using UnityEngine;
using System.Collections;

public class JumpingGuy : MonoBehaviour
{
    float randomDelay,y;

    void Start ()
    {
        Color newColour = new Color(Random.value, Random.value, Random.value, 1.0f);
        GetComponent<SpriteRenderer>().color = newColour;
        randomDelay = Random.Range(0.5f, 1.5f);
        StartCoroutine(jump());
	}

    IEnumerator jump()
    {
        while (true)
        {
            yield return new WaitForSeconds(randomDelay/2);
            y = this.transform.position.y + 10;
            this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
            yield return new WaitForSeconds(randomDelay / 2);
            y = this.transform.position.y - 10;
            this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
        }
    }
}
