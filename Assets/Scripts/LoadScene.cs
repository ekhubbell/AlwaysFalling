using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public static void loadGame(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void otherLoadGame(int i)
    {
        SceneManager.LoadScene(i);
    }
}
