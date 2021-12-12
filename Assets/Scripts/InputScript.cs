using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputScript : MonoBehaviour
{
    public InputField nicknameOne;
    public InputField nicknameTwo;
    public static string nicknameonestring;
    public static string nicknametwostring;

    public void createNickname()
    {
        if (!nicknameOne.text.Equals(""))
        {
            nicknameonestring = nicknameOne.text;
        }
        else { 
            nicknameonestring = "Nameless Goose 1";
        }

        if (!nicknameTwo.text.Equals(""))
        {
            nicknametwostring = nicknameTwo.text;
        }
        else
        {
            nicknametwostring = "Nameless Goose 2";
        }


       // Debug.Log(nicknamestring);
    }
    
}
