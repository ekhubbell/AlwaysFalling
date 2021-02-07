using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] meteorites;
    public GameObject[] lines;
    public float totalTime;
    float remainingTime;
    GameObject a;
    private int objectSpawned;
    public int colorChange;
    public static string color;
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = totalTime;
        objectSpawned = 0;
        color = "Blue";
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if(remainingTime<0f)
        {
            
            if(objectSpawned>=colorChange)
            {
                remainingTime = 6;
                objectSpawned = 0;
                a = Instantiate(differentLine());
                color = a.tag;
                a.transform.position = new Vector2(0, transform.position.y - 6);
            }
            else
            {
                remainingTime = Random.Range(totalTime, totalTime + 1);
                a = Instantiate(meteorites[Random.Range(0, 3)]);
                a.transform.position = new Vector2(Random.Range(-2.6f, 2.6f), transform.position.y - 6);
                objectSpawned++;
            }
        }
    }

    GameObject differentLine()
    {
        int r = Random.Range(0, lines.Length);
        if (lines[r].CompareTag(gameObject.tag))
            return differentLine();
        return lines[r];
    }
}
