using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correct : MonoBehaviour
{
    public string color;
    public bool correct;
    void Start()
    {
        correct = color.Equals(Spawner.color);
    }

}
