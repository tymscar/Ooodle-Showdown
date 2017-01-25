// This script animates the character

using UnityEngine;
using System.Collections;

public class Aniim : MonoBehaviour
{
    public GameObject explode;
    GameObject GM;
    PlayerMove moveScript;
    Animator animatorr;
    public GameObject stab;
    public int lives;

    void Start()
    {
        GM = GameObject.Find("GameController");
        moveScript = GetComponent<PlayerMove>();
        animatorr = GetComponent<Animator>();
        lives = 10;
    }

    void Update()
    {
        if (moveScript.playerNo == 1)
            Player1Anim();
        if (moveScript.playerNo == 2)
            Player2Anim();
    }

    void Player1Anim()
    {
        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") < 0 && !(Input.GetAxis("Horizontal") > 0) && !(Input.GetAxis("Vertical") < 0))
        {
            animatorr.Play("WalkUpRight");
        }
        else if (Input.GetAxis("Vertical") > 0 && !(Input.GetAxis("Horizontal") < 0) && (Input.GetAxis("Horizontal") > 0) && !(Input.GetAxis("Vertical") < 0))
        {
            animatorr.Play("WalkUpLeft");
        }
        else if (Input.GetAxis("Vertical") > 0 && !(Input.GetAxis("Horizontal") < 0) && !(Input.GetAxis("Horizontal") > 0) && !(Input.GetAxis("Vertical") < 0))
        {
            animatorr.Play("WalkUp");
        }
        else if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") < 0 && !(Input.GetAxis("Horizontal") > 0) && !(Input.GetAxis("Vertical") > 0))
        {
            animatorr.Play("WalkDownRight");
        }
        else if (Input.GetAxis("Vertical") < 0 && !(Input.GetAxis("Horizontal") < 0) && (Input.GetAxis("Horizontal") > 0) && !(Input.GetAxis("Vertical") > 0))
        {
            animatorr.Play("WalkDownLeft");
        }
        else if (Input.GetAxis("Vertical") < 0 && !(Input.GetAxis("Horizontal") < 0) && !(Input.GetAxis("Horizontal") > 0) && !(Input.GetAxis("Vertical") > 0))
        {
            animatorr.Play("WalkDown");
        }
        else if (Input.GetAxis("Horizontal") < 0 && !(Input.GetAxis("Vertical") > 0) && !(Input.GetAxis("Vertical") < 0) && !(Input.GetAxis("Horizontal") > 0))
        {
            animatorr.Play("WalkRight");
        }
        else if (Input.GetAxis("Horizontal") > 0 && !(Input.GetAxis("Vertical") > 0) && !(Input.GetAxis("Vertical") < 0) && !(Input.GetAxis("Horizontal") < 0))
        {
            animatorr.Play("WalkLeft");
        }
        else if (Input.GetKey("escape"))
            animatorr.Stop();

        if (Input.GetKey(KeyCode.E))
        {
            //Stabb stabby
            StartCoroutine(stabAction());
        }
    }

    void Player2Anim()
    {
        if (Input.GetAxis("Vertical2") > 0 && Input.GetAxis("Horizontal2") < 0 && !(Input.GetAxis("Horizontal2") > 0) && !(Input.GetAxis("Vertical2") < 0))
        {
            animatorr.Play("WalkUpRight");
        }
        else if (Input.GetAxis("Vertical2") > 0 && !(Input.GetAxis("Horizontal2") < 0) && (Input.GetAxis("Horizontal2") > 0) && !(Input.GetAxis("Vertical2") < 0))
        {
            animatorr.Play("WalkUpLeft");
        }
        else if (Input.GetAxis("Vertical2") > 0 && !(Input.GetAxis("Horizontal2") < 0) && !(Input.GetAxis("Horizontal2") > 0) && !(Input.GetAxis("Vertical2") < 0))
        {
            animatorr.Play("WalkUp");
        }
        else if (Input.GetAxis("Vertical2") < 0 && Input.GetAxis("Horizontal2") < 0 && !(Input.GetAxis("Horizontal2") > 0) && !(Input.GetAxis("Vertical2") > 0))
        {
            animatorr.Play("WalkDownRight");
        }
        else if (Input.GetAxis("Vertical2") < 0 && !(Input.GetAxis("Horizontal2") < 0) && (Input.GetAxis("Horizontal2") > 0) && !(Input.GetAxis("Vertical2") > 0))
        {
            animatorr.Play("WalkDownLEft");
        }
        else if (Input.GetAxis("Vertical2") < 0 && !(Input.GetAxis("Horizontal2") < 0) && !(Input.GetAxis("Horizontal2") > 0) && !(Input.GetAxis("Vertical2") > 0))
        {
            animatorr.Play("WalkDown");
        }
        else if (Input.GetAxis("Horizontal2") < 0 && !(Input.GetAxis("Vertical2") > 0) && !(Input.GetAxis("Vertical2") < 0) && !(Input.GetAxis("Horizontal2") > 0))
        {
            animatorr.Play("WalkRight");
        }
        else if (Input.GetAxis("Horizontal2") > 0 && !(Input.GetAxis("Vertical2") > 0) && !(Input.GetAxis("Vertical2") < 0) && !(Input.GetAxis("Horizontal2") < 0))
        {
            animatorr.Play("WalkLeft");
        }
        else if (Input.GetKey("escape"))
            animatorr.Play("Death");

        if (Input.GetButtonDown("Fire2"))
        {
            //Stabb stabby
            StartCoroutine(stabAction());
        }
    }

    IEnumerator stabAction()
    {
        stab.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        stab.SetActive(false);
    }


    IEnumerator dead()
    {
        animatorr.Play("Death");
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
    IEnumerator kill(GameObject other)
    {
        GameObject temp = other;
        Destroy(other);
        Instantiate(explode, other.transform.position, other.transform.rotation);
        yield return new WaitForSeconds(1f);
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.tag == "Player" || other.tag == "Bot")
        {
            if (other.gameObject.transform.parent) {
                if (other.gameObject.transform.parent.gameObject.transform == this.transform)
                {
                    //chill
                    print("Wub wub");
                }
                else
                {
                   
                    if (other.tag == "Player")
                    {
                        //kill another player
                        StartCoroutine(kill(other.gameObject));
                        GM.GetComponent<PlayerSelect>().numberOfPlayers--;
                    }
                    else
                    {
                        //kill a bot
                        StartCoroutine(kill(other.gameObject));
                        lives--;
                        if (lives < 1)
                        {
                            GM.GetComponent<PlayerSelect>().death();
                            StartCoroutine(dead());

                        }
                    
                  
                    }
                }
            }
            else
            {
                
                if (other.tag == "Player")
                {
                    //kill another player
                    StartCoroutine(kill(other.gameObject));
                    GM.GetComponent<PlayerSelect>().numberOfPlayers--;
                }
                else
                {
                    StartCoroutine(kill(other.gameObject));
                    //kill a bot
                    lives--;
                    if (lives < 1)
                    {
                        GM.GetComponent<PlayerSelect>().death();
                        StartCoroutine(dead());
                    }

                }
                
                
            }
        }
    }
}
