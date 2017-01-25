using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public Color bluem, greenm, orangem, redm, violetm, whitem, yellowm;
    public Color[] PlayerColour;
    void Start()
    {
        PlayerColour = new Color[4];
        PlayerColour[1] = bluem;
        PlayerColour[2] = greenm;
    }
}
