using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    
    GameObject player;
    private void Start()
    {
        player = transform.parent.gameObject;    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Meteoroid") && collision.gameObject.GetComponent<Correct>().correct)
        {
            Score.score = 0;
            Score.modifier = 1f;
        }
        Destroy(collision.gameObject);
    }
}
