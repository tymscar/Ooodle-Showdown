// This script choses the number of players

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerSelect : MonoBehaviour
{
    public GameObject GameOver;
    private bool numberSelected = false;
    public Text Instruction1;
    public Text Instruction2;
    public Text numberText;
    public Image MiddleImage;
    bool[] ColoursChosen;
    int currentPlayer = 1;
    public int numberOfPlayers = 1;
    public Color bluem, greenm, orangem, redm, violetm, whitem, yellowm;
    void Start()
    {
        DontDestroyOnLoad(this);
        GameOver.SetActive(false);
        ColoursChosen = new bool[8];
        for (int i = 1; i <= 7; i++)
            ColoursChosen[i] = false;
        StartCoroutine(checkKeyWithDelay());
        MiddleImage.gameObject.SetActive(false);
    }

    IEnumerator checkKeyWithDelay()
    {
        while (!numberSelected)
        {
            if (Input.GetKey("up"))
                numberOfPlayers++;
            if (Input.GetKey("down"))
                numberOfPlayers--;
            if (Input.GetKey(KeyCode.Return))
                numberSelected = true;
            if (numberOfPlayers > 4)
                numberOfPlayers = 4;
            if (numberOfPlayers < 1)
                numberOfPlayers = 1;
            numberText.text = numberOfPlayers + "";
            yield return new WaitForSeconds(0.075f);
        }
        StartCoroutine(selectPlayerColour());
    }

    IEnumerator selectPlayerColour()
    {
        int i = 1;
        numberSelected = false;
        //Instruction2.gameObject.SetActive(false);
        Instruction2.text = "Go through the colours using the Up and Down arrows.\nPress Enter to start the game";
        numberText.gameObject.SetActive(false);
        MiddleImage.gameObject.SetActive(true);
        while (!numberSelected)
        {
            Instruction1.text = "Select the colour for player" + currentPlayer + "!";
            if (i == 1 && ColoursChosen[i] == false)
            {
                MiddleImage.color = bluem;
            }
            if (i == 1 && ColoursChosen[i] != false)
            {
                i++;
            }
            if (i == 2 && ColoursChosen[i] == false)
            {
                MiddleImage.color = greenm;
            }
            if (i == 2 && ColoursChosen[i] != false)
            {
                i++;
            }
            if (i == 3 && ColoursChosen[i] == false)
            {
                MiddleImage.color = orangem;
            }
            if (i == 3 && ColoursChosen[i] != false)
            {
                i++;
            }
            if (i == 4 && ColoursChosen[i] == false)
            {
                MiddleImage.color = redm;
            }
            if (i == 4 && ColoursChosen[i] != false)
            {
                i++;
            }
            if (i == 5 && ColoursChosen[i] == false)
            {
                MiddleImage.color = violetm;
            }
            if (i == 5 && ColoursChosen[i] != false)
            {
                i++;
            }
            if (i == 6 && ColoursChosen[i] == false)
            {
                MiddleImage.color = whitem;
            }
            if (i == 6 && ColoursChosen[i] != false)
            {
                i++;
            }
            if (i == 7 && ColoursChosen[i] == false)
            {
                MiddleImage.color = yellowm;
            }
            if (i == 7 && ColoursChosen[i] != false)
            {
                i++;
            }
            if (Input.GetKey("up"))
                i++;
            if (Input.GetKey("down"))
                i--;
            if (i >= 8)
                i = 1;
            if (i <= 0)
                i = 7;
            if (Input.GetKey(KeyCode.Return))
            {
                ColoursChosen[i] = true;
                currentPlayer++;
            }
            if (currentPlayer == numberOfPlayers +1)
            {
                numberSelected = true;
            }
            yield return new WaitForSeconds(0.075f);
        }
        Application.LoadLevel(2);
    }

    public void death()
    {
        numberOfPlayers--;
        if(numberOfPlayers <= 1)
        {
            GameOver.SetActive(true);
        }
    }

}
