using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] meteorites;
    public float totalTime;
    float remainingTime;
    GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if(remainingTime<0f)
        {
            remainingTime = totalTime;
            a = Instantiate(meteorites[Random.Range(0, 3)]);
            a.transform.position = new Vector2(Random.Range(-4f, 4f), transform.position.y-5);
        }
    }
}
