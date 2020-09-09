using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(2);
        }
    }
}
