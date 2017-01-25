// This the is class attached to every ping. It scales the ping!

using UnityEngine;
using System.Collections;

public class PingClass : MonoBehaviour
{
    float x, y, z;
    void Start()
    {
        StartCoroutine(increaseSize());
        StartCoroutine(Dying());
    }

    IEnumerator increaseSize()
    {
        while (true)
        {
            x = this.transform.localScale.x;
            y = this.transform.localScale.y;
            z = this.transform.localScale.z;
            x += 0.4f;
            y += 0.4f;
            z += 0.4f;
            this.transform.localScale = new Vector3(x, y, z);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Dying()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
