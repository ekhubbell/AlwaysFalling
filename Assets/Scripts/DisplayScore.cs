﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    //Score score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        //score = new Score();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Score.score;
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highscore",0);
    }
}
