using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFalling : MonoBehaviour
{
    public float speed;
    public float fallSpeed;

    public float Maxfallspeed;

    public bool spacePressed;

    private Rigidbody2D myRb;


    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>(); //gets RidgidBody 2D

        spacePressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        myRb.velocity = new Vector2(myRb.velocity.x, -fallSpeed); //player is constantly falling downwards

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x<4.8)
        {
            myRb.velocity = new Vector2(speed, myRb.velocity.y); //moves player right
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -4.8)
        {
            myRb.velocity = new Vector2(-speed, myRb.velocity.y); //moves player right
        }
        else if (!(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))) //if the player is not pressing anything
        {
            myRb.velocity = new Vector2(0, myRb.velocity.y); //stop the player
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine("WaitTime"); //starts a wait for seconds
        }

        if(spacePressed == true)
        {
            if (fallSpeed <= Maxfallspeed)
            {
                fallSpeed += 0.5f; //speeds up the fall speed until reaching the max
            }
            else
            {
                spacePressed = false;
            }
        }
    }

    private IEnumerator WaitTime()
    {
        //fallSpeed = 0; //suspends the player briefly

        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(0.5f);
        spacePressed = true; //starts speeding up the fall to the fall speed max
        Time.timeScale = 1.0f;
    }
}
