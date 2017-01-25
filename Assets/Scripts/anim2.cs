using UnityEngine;
using System.Collections;

public class anim2 : MonoBehaviour {
    // This script animates the character

    Animator animatorr;
    public GameObject parent;
    public float temp;
    void Start()
    {
        animatorr = GetComponent<Animator>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, -45,0);
        temp = (180 * (parent.transform.rotation.y + 1)) + 180;
        if(temp > 360)
        {
            temp -= 360;
        }
        if ( temp > 292 && temp < 337)
        {
            animatorr.Play("WalkUpLeft");
            
        }
        else if (temp > 22 && temp < 67)
        {
            animatorr.Play("WalkUpRight");
        }
        else if (temp > 337 || temp < 22)
        {
            animatorr.Play("WalkUp");
        }
        else if (temp > 202 && temp < 247)
        {
            animatorr.Play("WalkDownLeft");
        }
        else if (temp > 112 && temp < 157)
        {
            animatorr.Play("WalkDownRight");
        }
        else if (temp > 157 && temp < 202)
        {
            animatorr.Play("WalkDown");
        }
        else if (temp > 247 && temp < 292)
        {
            animatorr.Play("WalkLeft");
        }
        else if (temp > 67 && temp < 112)
        {
            animatorr.Play("WalkRight");
            
        }
        else if (Input.GetKey("escape"))
            animatorr.Play("Death");
    }
}
