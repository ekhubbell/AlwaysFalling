using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject followThis;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().velocity = new Vector3(0, followThis.GetComponent<Rigidbody2D>().velocity.y, 0);

        transform.position = new Vector3(transform.position.x, followThis.transform.position.y-offset, transform.position.z);
    }
}
