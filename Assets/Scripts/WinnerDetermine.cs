using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerDetermine : MonoBehaviour
{
    public Text WinnerName;
    // Start is called before the first frame update
    void Start()
    {
        WinnerName.text = FighterMovement.WinnerName;

        if (FighterMovement.isPurple)
        {
            WinnerName.color = Color.magenta;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
