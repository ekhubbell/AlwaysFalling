using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseScript : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gamePanel;
    public GameObject GameOverPanel;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public Sprite audioOn;
    public Sprite audioOff;

    public GameObject player;
    GameObject sound;

    bool pressedThisTurn = false;

    public static event Action Restart = delegate { };

    private void Start()
    {
        sound = GameObject.FindGameObjectWithTag("Audio");
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOverPanel.activeInHierarchy && Input.GetMouseButtonUp(0) && !pressedThisTurn)
        {
            if(Time.timeScale!=0)
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
                gamePanel.SetActive(false);
                scoreText.text = "Score: " + Score.score;
                highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highscore", 0);
            }
        }
        else if(pressedThisTurn)
        {
            pressedThisTurn = false;
        }
        
    }

    public void ToggleAudio(Image image)
    {
        if (image.sprite == audioOn)
        {
            image.sprite = audioOff;
            player.GetComponent<AudioSource>().enabled = false;
            sound.GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            image.sprite = audioOn;
            player.GetComponent<AudioSource>().enabled = true;
            sound.GetComponent<AudioSource>().enabled = true;
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        gamePanel.SetActive(true);
        pressedThisTurn = true;
    }

    public void ResetTime()
    {
        Time.timeScale = 1;
    }

    public void loadScene(int i)
    {
        pressedThisTurn = true;
        if(Time.timeScale!=1)
        {
            Time.timeScale = 1;
        }
        LoadScene.loadGame(i);
    }

    public void Rest()
    {
        pressedThisTurn = true;
        Restart();
    }
}
