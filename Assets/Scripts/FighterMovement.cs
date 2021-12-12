using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FighterMovement : MonoBehaviour
{
    public GameObject Goose2;
    public GameObject Goose1;

    public Sprite GooseStay;
    public Sprite GooseMove;
    public Text Shock1;
    public Text Shock2;
    public Sprite PGooseStay;
    public Sprite PGooseMove;

    public int maxSpeed=40;
    public int minSpeed=-10;
    public double speedBoundry;
    public double penaltyRatio;
    public int penaltyAmt;
    public int speed;

    public int penalty1;
    public int penalty2;

    public GameObject TempHonk;
    public GameObject HonkHigh;
    public AudioSource Tada;


    public Collider2D FinishLine;

    public GameObject Dimmer;
    public Text CountdownText;

    private bool Playable;
    public static string WinnerName;
    public static bool isPurple;

   // public AudioSource audioData;
   // public AudioClip clip;


    IEnumerator Countdown()
    {
        CountdownText.text = "3";
        yield return new WaitForSeconds(1f);
        CountdownText.text = "2";
        yield return new WaitForSeconds(1f);
        CountdownText.text = "1";
        yield return new WaitForSeconds(1f);
        CountdownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        Playable = true;
       // CountdownText.gameObject.SetActive(false);
        Dimmer.gameObject.SetActive(false);
        yield return null;
    }


    private void Start()
    {
        CountdownText.gameObject.SetActive(true);
        StartCoroutine(Countdown());
        isPurple = false;
        Playable = false;
        penalty1 = penalty2 = 0;
        penaltyRatio = 0.6;
        penaltyAmt = -100;

        if (maxSpeed < minSpeed)
            Debug.LogError("minSpeed is greater than maxSpeed");
        
        speedBoundry = (maxSpeed - minSpeed) * penaltyRatio + minSpeed;

    }



    void Update()
    {
        Goose2.GetComponent<Image>().sprite = GooseStay;
        Goose1.GetComponent<Image>().sprite = PGooseStay;

      
         
        if (Playable == true)
        {
            if (Keyboard.current.lKey.wasPressedThisFrame)
            {
                speed = Random.Range(minSpeed, maxSpeed);
                Goose2.transform.Translate(speed, 0, 0);
                Shock2.gameObject.SetActive(false);
                if (speed >= speedBoundry)
                {
                    penalty2++;
                }
                if (penalty2 >= 20)
                {
                    Goose2.transform.Translate(penaltyAmt, 0, 0);
                    Shock2.gameObject.SetActive(true);
                    penalty2 = 0;
                }

                StartCoroutine(PlaySound());
               


            }
            if (Keyboard.current.lKey.isPressed)
            {
                Goose2.GetComponent<Image>().sprite = GooseMove;
              
            }

            if (Keyboard.current.dKey.wasPressedThisFrame)
            {
                speed = Random.Range(minSpeed, maxSpeed);
                Goose1.transform.Translate(speed, 0, 0);
                Shock1.gameObject.SetActive(false);
                if (speed >= speedBoundry)
                {
                    penalty1++;
                }
                if (penalty1 >= 20)
                {
                    Goose1.transform.Translate(penaltyAmt, 0, 0);
                   Shock1.gameObject.SetActive(true);
                    penalty1 = 0;
                }
                StartCoroutine(PlaySoundH());
            }
            if (Keyboard.current.dKey.isPressed)
            {
                Goose1.GetComponent<Image>().sprite = PGooseMove;
               
            }

        }

    }

    IEnumerator PlaySound()
    {
        Instantiate(TempHonk);
        yield return null;
       // Destroy(TempHonk);
    }

    IEnumerator PlaySoundH()
    {
        Instantiate(HonkHigh);
        yield return null;
        // Destroy(TempHonk);
    }

    public void hasWon()
    {
        if (Trigger.IdentifyName().Equals("Goose2"))
        {
            WinnerName = InputScript.nicknametwostring;
        } else if (Trigger.IdentifyName().Equals("Goose1"))
        {
            WinnerName = InputScript.nicknameonestring;
            isPurple = true;
        }
       
       
        Debug.Log(WinnerName + " has won!");
       // WinnerName = Trigger.IdentifyName();
       
        
        StartCoroutine(WinningSequence());
       
    }

    IEnumerator WinningSequence()
    {
        Playable = false;
        Tada.PlayOneShot(Tada.clip);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Winner screen");
    }
}
