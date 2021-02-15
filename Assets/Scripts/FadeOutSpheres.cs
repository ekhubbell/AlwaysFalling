using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutSpheres : MonoBehaviour
{
    private Animator anim;
    private CircleCollider2D circle;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        circle = GetComponent<CircleCollider2D>();
        Score.GameOver += GameOver;
    }

    void GameOver()
    {
        if(gameObject!=null)
        {
            circle.enabled = false;
            anim.SetTrigger("go");
        } 
    }

    void Delete()
    {
        Score.GameOver -= GameOver;
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        Score.GameOver -= GameOver;
    }
}
