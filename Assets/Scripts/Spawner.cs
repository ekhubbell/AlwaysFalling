using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject[] meteorites;
    public GameObject[] lines;

    public GameObject gameOverPrefab;
    public GameObject gameOverPanel;
    public GameObject gamePanel;

    public float totalTime;
    float remainingTime;
    GameObject a;
    private int objectSpawned;
    public int colorChange;
    public static string color;

    public TextMeshProUGUI finalScore;

    GameObject r;
    bool rActive;
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = totalTime;
        objectSpawned = 0;
        color = "Blue";
        Score.GameOver += GameOver;
        rActive = false;
        PauseScript.Restart += Restart;
    }

    // Update is called once per frame
    void Update()
    {
        if(!rActive)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime < 0f)
            {

                if (objectSpawned >= colorChange - Mathf.Log(Score.modifier, 3))
                {
                    objectSpawned = 0;
                    a = Instantiate(differentLine());
                    color = a.tag;
                    a.transform.position = new Vector2(0, transform.position.y - 6);
                }
                else
                {
                    a = Instantiate(meteorites[Random.Range(0, 3)]);
                    a.transform.position = new Vector2(Random.Range(-2.6f, 2.6f), transform.position.y - 6);
                    objectSpawned++;
                }
                remainingTime = Random.Range(totalTime, totalTime + 1);
            }
        }
        
    }

    GameObject differentLine()
    {
        int ran = Random.Range(0, lines.Length);
        if (lines[ran].CompareTag(gameObject.tag))
            return differentLine();
        return lines[ran];
    }

    void GameOver()
    {
        r = Instantiate(gameOverPrefab);
        r.transform.position = new Vector3(0, transform.position.y-6, 0);
        remainingTime = 2.5f;
        rActive = true;
        StartCoroutine(moveRestart());
    }

    IEnumerator moveRestart()
    {
        Vector3 start = r.transform.position;
        Vector3 end = new Vector3(0f, transform.position.y - 2.8f,0f);
        float elapsedTime = 0f;
        while(elapsedTime < totalTime +1)
        {
            start = new Vector3(0, transform.position.y - 6, 0);
            end = new Vector3(0f, transform.position.y + 2.8f, 0f);
            r.transform.position = Vector3.Lerp(start, end, elapsedTime / (totalTime+1));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        r.transform.position = new Vector3(0f, transform.position.y + 2.8f, 0f);

        follow fol =r.AddComponent<follow>();
        fol.followThis = gameObject;
        fol.offset = -2.8f;
        fol.gameOver = false;
        yield return new WaitForSeconds(.05f);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        finalScore.text = "Final Score: " + PlayerPrefs.GetInt("Score", -1);
    }

    void Restart()
    {
        gamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        rActive = false;
        Destroy(r);
    }

    private void OnDestroy()
    {
        Score.GameOver -= GameOver;
        PauseScript.Restart -= Restart;
    }
}
