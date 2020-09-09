using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingSpeedControll : MonoBehaviour
{
    public float fallSpeed;
    Rigidbody2D myRb;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRb.velocity = new Vector2(0, -fallSpeed);
    }
}
