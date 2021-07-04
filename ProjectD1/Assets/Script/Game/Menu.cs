using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject HighscorePanel;

    // Start is called before the first frame update

    //Âm thanh cho Menu
    public AudioSource aus;
    public AudioClip play;
    public AudioClip info;
    public AudioClip highscore;
    public AudioClip quit;


    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        if (aus && play)
        {
            aus.PlayOneShot(play);
        }
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        if (aus && quit)
        {
            aus.PlayOneShot(quit);
        }
        Application.Quit();
    }

    public void Info()
    {
        if (aus && info)
        {
            aus.PlayOneShot(info);
        }
        InfoPanel.SetActive(true);
    }

    public void Highscore()
    {
        if (aus && highscore)
        {
            aus.PlayOneShot(highscore);
        }
        HighscorePanel.SetActive(true);
    }
}
