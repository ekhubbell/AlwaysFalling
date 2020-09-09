using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score;
    public static int highscore;
    public static float modifier = 1.0f;

    public AudioClip bell;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.localScale == transform.localScale)
        {
            score += 1 * (int)modifier;
            modifier += 0.5f;
            collision.gameObject.GetComponent<AudioSource>().PlayOneShot(bell);
        }
        else
        {
            score =0;
            modifier = 1;
        }
        Destroy(gameObject);
    }

    private void Update()
    {
        if(score> highscore)
        {
            highscore = score;
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
