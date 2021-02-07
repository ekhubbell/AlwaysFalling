using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFalling : MonoBehaviour
{
    public float speed;
    public float fallSpeed;

    bool isColliding;
    CircleCollider2D circle;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        circle = GetComponent<CircleCollider2D>();
        dir = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float acc = Input.acceleration.x;
        if(acc==0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                acc = -.25f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                acc = .25f;
            }
        }

        if (!((dir.x>0 &&acc>0)||(dir.x < 0 && acc < 0)))
        {
            dir.x = 0;
        }
        dir.x += acc;
        

        //if (dir.sqrMagnitude > 1)
        //    dir.Normalize();

        //for debugging in editor
        

        dir.x *= speed;
        dir.y = -fallSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.fixedDeltaTime;

        

        if (dir.x < 0)
        {
            isColliding = checkCollision(Vector2.left);
        }
        else if(dir.x>0)
        {
            isColliding = checkCollision(Vector2.right);
        }

        if(!isColliding)
        {
            transform.Translate(dir);
        }
        else
        {
            transform.Translate(new Vector3(0,dir.y,0));
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

}
