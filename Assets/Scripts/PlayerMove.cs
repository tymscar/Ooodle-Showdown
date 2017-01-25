// This is the class that deals with player movement

using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int playerNo;
    public float speed = 3.0f;
    float x, z;
    void Update()
    {
        if (playerNo == 1)
        {
            x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        }
        else
        {
            x = Input.GetAxis("Horizontal2") * Time.deltaTime * speed;
            z = Input.GetAxis("Vertical2") * Time.deltaTime * speed;
        }
        transform.Translate(-x, 0, -z);
    }
}