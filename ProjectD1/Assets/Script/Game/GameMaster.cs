using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class GameMaster : MonoBehaviour {

    public int steps;
    public int Points;
    public bool gameOver = false;
    public float delay = 1.2f;

    public Player player;
    public Text steps_text;
    public Text score_text;
    public GameObject gameover;
    public GameObject gamestart;
    public GameObject win;

	// Use this for initialization
	void Start ()
    {
        steps = 30;
        Points = 0;
        gameover.SetActive(false);
        gamestart.SetActive(true);

        if (PlayerPrefs.HasKey("points"))
        {
            Scene ActiveScene = SceneManager.GetActiveScene();
            if (ActiveScene.buildIndex == 1)
            {
                PlayerPrefs.DeleteKey("points");
                PlayerPrefs.DeleteKey("highscore");
                Points = 0;
            }
            else Points = PlayerPrefs.GetInt("points");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gamestart.activeInHierarchy == true)
        {
            if (delay > 0) delay -= Time.deltaTime;
            else gamestart.SetActive(false);
        }

        if (steps > 0)
        {
            gameOver = false;
        }
        else gameOver = true;

        if (gameOver == true)
        {
            player.IsDead = true;
        }

        steps_text.text = steps.ToString();
        score_text.text = Points.ToString();
    }
}
