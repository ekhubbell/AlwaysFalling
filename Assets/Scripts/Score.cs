using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score=0;
    public static int highscore=0;
    public static float modifier = 1.0f;

    public AudioClip bell;

    private void Start()
    {
        
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
            }
            else
            {
                score = 0;
                modifier = 1f;
            }
            Destroy(collision.gameObject);
        }
            
        
    }

    private void Update()
    {
        if(score> highscore)
        {
            highscore = score;
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
        return highscore;
    }

}
