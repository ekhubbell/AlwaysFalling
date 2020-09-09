using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip bell;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.transform.localScale == gameObject.transform.localScale)
        {
            GetComponent<AudioSource>().PlayOneShot(bell);
        }
    }
}
