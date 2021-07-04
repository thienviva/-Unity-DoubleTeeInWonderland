using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Highscore_Table : MonoBehaviour
{
    public Text HighScore;
    public string highscore;
    public string[] higharr = new string[3];
    // Start is called before the first frame update
    void Start()
    {
        highscore = "TOP 3";
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadData()
    {
        try
        {
            // tao instance cua StreamReader de doc mot file.
            // lenh using cung duoc su dung de dong StreamReader.
            using (StreamReader sr = new StreamReader("highscore.txt"))
            {
                string line;
                int i = 0;
                // doc va hien thi cac dong trong file cho toi
                // khi tien toi cuoi file. 
                while ((line = sr.ReadLine()) != null && i < 3)
                {
                    higharr[i] = line;
                    i++;
                }
                for (i = 0; i < 3; i++)
                {
                    highscore = highscore + "\n" + higharr[i];
                }
            }
        }
        catch (Exception e)
        {
            highscore = e.ToString();
        }
        
        HighScore.text = highscore;
    }
}
