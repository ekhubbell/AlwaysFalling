using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnection : MonoBehaviour
{
    public LineRenderer top;
    public LineRenderer bot;
    LineRenderer mid;
    int vert;
    int[] mod = { -2, -1, 0, 1, 2, 3, 2, 1, 0, -1, -2, -3 };
    // Start is called before the first frame update
    void Start()
    {
        mid = GetComponent<LineRenderer>();
        vert = top.GetComponent<LineScript>().vertices;
        mid.positionCount = vert;
    }

    // Update is called once per frame
    void Update()
    {
        //AnimationCurve curve = new AnimationCurve();
        for (int i=0; i<vert; i++)
        {
            float topPoint = top.GetPosition(i).y;
            float botPoint = bot.GetPosition(i).y;
            float point = Mathf.Lerp(botPoint, topPoint, .001f) * mod[i % 12] * .25f;
            mid.SetPosition(i, new Vector3(top.GetPosition(i).x, point, 0f));
            
            //curve.AddKey((float)i / vert, Mathf.Clamp(Mathf.Lerp(botPoint, topPoint, .5f), 0.1f, 1f));
            //curve.AddKey((float)i / vert, Mathf.Lerp(botPoint, topPoint,topPoint - botPoint));

            //if (i % 6 > 2)
            //{
            //    mid.SetPosition(i, new Vector3(top.GetPosition(i).x, Mathf.Abs(topPoint - botPoint), 0f));
            //}
            //else
            //{
            //    mid.SetPosition(i, new Vector3(top.GetPosition(i).x, -1 * Mathf.Abs(topPoint - botPoint), 0f));
            //}

        }

        //mid.widthCurve = curve;
    }
}
