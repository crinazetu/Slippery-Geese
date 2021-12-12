using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{

    public GameObject inputWindow;
    public GameObject instructionWindow;

   // public AudioSource Clicker;
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
   
    }

    public void StartGameWithInstructions()
    {
        SceneManager.LoadScene("Instruction Screen");
  
    }

    public void Understand()
    {
        inputWindow.SetActive(true);
        instructionWindow.SetActive(false);
    
    }
    public void BackToTitle()
    {
        SceneManager.LoadScene("Title Screen");

    }

    public void QuitGame()
    {
     
        Application.Quit();

    }

   

   
}
