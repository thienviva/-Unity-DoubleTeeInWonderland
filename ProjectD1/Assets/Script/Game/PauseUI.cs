using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    private bool pause = false;
    private bool mute = false;
    public GameObject pauseUI;

    //thay đổi hình ảnh
    public Sprite soundOff;
    public Sprite soundOn;

    //Âm thanh 
    public AudioSource aus;
    public AudioClip menu;
    public AudioClip restart;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }

        if(pause == true)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if(pause == false)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void Restart()
    {
        if (aus && restart)
        {
            aus.PlayOneShot(restart);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        
        if (aus && menu)
        {
            aus.PlayOneShot(menu);
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Mute(Button button)
    {
        if (aus && sound)
        {
            aus.PlayOneShot(sound);
        }

        if (Input.mousePresent)
        {
            mute = !mute;
        }

        if(mute == true)
        {
            button.GetComponent<Image>().sprite = soundOff;
            aus.volume = 0;

        }
        
        if(mute == false)
        {
            button.GetComponent<Image>().sprite = soundOn;
            aus.volume = 1;
        }

    }
}
