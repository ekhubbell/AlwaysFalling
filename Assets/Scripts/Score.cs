using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score=0;
    public static int highscore=0;
    public static float modifier = 1.0f;

    public static event Action GameOver = delegate { };
    //bool gameOver;
    public AudioClip bell;

    public GameObject[] particles;


    public TextMeshProUGUI db;
    private void Start()
    {
        //gameOver = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meteoroid"))
        {
            if (collision.gameObject.GetComponent<Correct>().correct)
            {
                score += 1 * (int)modifier;
                modifier += 0.5f;
                gameObject.GetComponent<AudioSource>().PlayOneShot(bell);
                for(int i=0; i<particles.Length; i++)
                {
                    if (particles[i].CompareTag(gameObject.tag))
                    {
                        Instantiate(particles[i], gameObject.transform);
                        break;
                    }
                }
                Destroy(collision.gameObject);
            }
            else
            {
                GameOver();
                PlayerPrefs.SetInt("Score", score);
                score = 0;
                modifier = 1f;
            }
            
        }     
        
    }

    private void Update()
    {
        if(score> PlayerPrefs.GetInt("highscore",0))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        if (modifier < 1)
        {
            modifier = 1;
        }
        if (score < 0)
        {
            score = 0;
        }
    }


    public int returnScore()
    {
        return score;
    }

    public int returnHighScore()
    {
        return PlayerPrefs.GetInt("highscore",0);
    }

}
