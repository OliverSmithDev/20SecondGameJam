using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float Score;
    public float Timer;
    public float PreGameTimer;
    public bool preGameTimerOn;

    public TMP_Text ScoreText;
    public TMP_Text TimerText;
    public TMP_Text pregametext;
    public GameObject pregameobj;
    public GameObject pregameDeletion;

    public AudioSource carSound;
    
    
    
    // Menu
    public GameObject endScreen;
    public TMP_Text endScore;
    public GameObject menu;
    

    // Update is called once per frame
    void Update()
    {
        if (preGameTimerOn)
        {
            PreGameTimer -= Time.deltaTime;
            pregametext.text = PreGameTimer.ToString("f2");
        }

        if (PreGameTimer <= 0)
        {
            pregameobj.SetActive(false);
            pregameDeletion.SetActive(false);
            preGameTimerOn = false;
            Timer -= Time.deltaTime;
            ScoreText.text = "Score =   " + Score;
            TimerText.text = "Time Left =   " + Timer.ToString("f2");

            if (Timer <= 0)
            {
                Timer = 0;
                EndGame();
            }
        }

        
    }
    void EndGame()
    {
        endScreen.SetActive(true);
        endScore.text = "Final Score =   " + Score;
    }

    public void Play()
    {
        menu.SetActive(false);
        preGameTimerOn = true;
        carSound.Play();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
