﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOrShrink : MonoBehaviour
{
    public Vector3 small;
    public Vector3 normal;
    public Vector3 big;

    TrailRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        transform.localScale = normal;
        trail.startWidth = 0.735f;
        trail.time = 0.2f;
        changeColor(new Vector3(0, 0.3725f, 1.0f), new Vector3(0, 0.9843f, 0.9765f));
        gameObject.tag = "Blue";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Green"))
        {
            transform.localScale = small;
            trail.startWidth = 0.495f;
            trail.time = 0.1f;
            changeColor(new Vector3(0, 1.0f, 0.03922f), new Vector3(0, 0.9882f, 0.7412f));
            gameObject.tag = "Green";
        }
        else if(collision.gameObject.CompareTag("Blue"))
        {
            transform.localScale = normal;
            trail.startWidth = 0.735f;
            trail.time = 0.2f;
            changeColor(new Vector3(0, 0.3725f, 1.0f), new Vector3(0, 0.9843f, 0.9765f));
            gameObject.tag = "Blue";
        }
        else if(collision.gameObject.CompareTag("Purple"))
        {
            transform.localScale = big;
            trail.startWidth = 1.0f;
            trail.time = 0.3f;
            changeColor(new Vector3(0.9922f, 0, 0.9922f), new Vector3(0.3333f, 0, 1.0f));
            gameObject.tag = "Purple";
        }
    }


    void changeColor(Vector3 start, Vector3 end)
    {
        trail.startColor = new Color(start.x, start.y, start.z);
        trail.endColor = new Color(end.x, end.y, end.z);
        GetComponent<SpriteRenderer>().color = new Color(start.x, start.y, start.z);
    }
}
