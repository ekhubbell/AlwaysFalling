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
            Score.modifier = Mathf.Clamp(1f, Score.modifier, Score.modifier - 1);
        }
        Destroy(collision.gameObject);
    }
}
