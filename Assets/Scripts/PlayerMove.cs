using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float maxSpeed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");

        float Vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(Horizontal, Vertical);
        //Debug.Log(move);
        rb.AddForce(move * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "shrink")
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        } else if (collision.gameObject.tag == "enlarge")
        {
            transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        }
    }
}
