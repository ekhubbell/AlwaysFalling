using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling : MonoBehaviour
{
    public float speed;
    private Renderer r;
    private float prevMod;
    public float slowTime;
    private bool changing;
    // Use this for initialization
    Vector2 offset;
    void Start()
    {
        r = GetComponent<Renderer>();
        changing = false;
        offset = Vector2.zero;
    }
    // Update is called once per frame
    void Update()
    {
        if (!changing)
        {
            if(prevMod==Score.modifier)
            {
                ChangeOffset(prevMod);
            }
            else
            {
                StartCoroutine(ChangeSpeed());
            }
        }
    }

    IEnumerator ChangeSpeed()
    {
        changing = true;
        float timeElapsed = 0f;

        while(timeElapsed<slowTime)
        {
            //Debug.Log(prevMod + ", " + Score.modifier + ", " + Mathf.Lerp(prevMod, Score.modifier, timeElapsed / slowTime));
            ChangeOffset(Mathf.Lerp(prevMod, Score.modifier, timeElapsed / slowTime));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        prevMod = Score.modifier;
        ChangeOffset(prevMod);
        changing = false;
    }

    void ChangeOffset(float mod)
    {
        offset.y += -Time.deltaTime * speed * Mathf.Clamp(mod, 1f, 7f);
        r.material.mainTextureOffset = offset;
    }
}
