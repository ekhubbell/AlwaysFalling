using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerFalling : MonoBehaviour
{
    public float speed;
    public float fallSpeed;

    bool isColliding;
    CircleCollider2D circle;
    Vector3 dir;

    bool gameOver;
    bool center;

    float remainingTime;
    float totalTime = 4;
    // Start is called before the first frame update
    void Start()
    {
        center = false;
        circle = GetComponent<CircleCollider2D>();
        dir = Vector3.zero;
        Debug.Log(Time.timeScale);
        gameOver = false;
        Score.GameOver += GameOver;
        PauseScript.Restart += Restart;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float acc = Input.acceleration.x;
        if(acc==0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                acc = -.35f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                acc = .35f;
            }
        }

        if (!((dir.x>0 &&acc>0)||(dir.x < 0 && acc < 0)))
        {
            dir.x = 0;
        }
        dir.x += acc;
        if(gameOver)
        {
            if (remainingTime<totalTime)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(0f, transform.position.y, 0f), remainingTime / totalTime);
                remainingTime += Time.fixedDeltaTime;
            }
            dir.x = 0;
        }
        
        float mod = Mathf.Log(Score.modifier, 2);
        if(mod<0)
        {
            mod = 0;
        }
        dir.x *= speed + (mod*.1f);
        dir.y = -(fallSpeed + mod);

        dir *= Time.fixedDeltaTime;
        

        if (dir.x < 0)
        {
            isColliding = checkCollision(Vector2.left);
        }
        else if(dir.x>0)
        {
            isColliding = checkCollision(Vector2.right);
        }
        if(!center)
        {
            if (!isColliding)
            {
                transform.Translate(dir);
            }
            else
            {
                transform.Translate(new Vector3(0, dir.y, 0));
            }
        }
        
    }

    bool checkCollision(Vector2 direction)
    {
        Vector2 origin = circle.bounds.center;
        float distance = circle.radius + .05f;

        RaycastHit2D hitInfo = Physics2D.Raycast(origin, direction, distance,256);
        if(hitInfo.collider!=null)
        {
            //Debug.Log(hitInfo);
            return true;
        }
        return false;
    }

    void GameOver()
    {
        gameOver = true;
        remainingTime = 0f;
    }


    void Restart()
    {
        gameOver = false;
    }

}
