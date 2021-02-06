using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public int vertices;
    private LineRenderer line;
    private float[] heightMax;
    private bool[] direction;

    private float heightScale;
    private float xScale;
    private float max;

    public bool once;
    public bool inverse;
    float j;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = vertices;
        heightScale = 1.0f;
        xScale = 2.0f;
        heightMax = new float[vertices];
        direction = new bool[vertices];
        max = 0f;
        j = 0;
        if(inverse)
        {
            for (int i = 0; i < vertices; i++)
            {
                j += Random.Range(0.0097f, 0.0256f);
                heightMax[i] = heightScale * Mathf.PerlinNoise(j * xScale, 0.0f);
                if (heightMax[i] > max)
                {
                    max = heightMax[i];
                }
            }
        }
        else
        {
            for(int i=vertices-1; i>=0; i--)
            {
                j += Random.Range(0.0097f, 0.0256f);
                heightMax[i] = heightScale * Mathf.PerlinNoise(j * xScale, 0.0f);
                if (heightMax[i] > max)
                {
                    max = heightMax[i];
                }
            }
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        //if(j<vertices)
        //{
        //    heightMax[j] = heightScale * Mathf.PerlinNoise(Time.time* xScale, 0.0f);
        //    //direction[j] = false;
            
        //    if (heightMax[j]>max)
        //    {
        //        max = heightMax[j];
        //    }
        //    j++;


        //    //for(int i=0; i<vertices; i++)
        //    //{
        //    //    heightMax[i] = heightScale * Mathf.PerlinNoise((Time.deltaTime*1000 / (float)(i + 1)) * xScale, 0.0f);
        //    //    direction[i] = false;
        //    //}
        //    //once = true;
        //}
        //else
        //{
            for(int i=0; i<vertices; i++)
            {
                float h = line.GetPosition(i).y;

                //if (direction[i])
                if(once)
                {
                    h += 0.005f*heightMax[i];
                    //if(h >= heightMax[i])
                    if(h>=max)
                    {
                        once = false;
                        //direction[i] = false;
                    }
                }
                else
                {
                    h -= 0.005f*heightMax[i];
                    //if (h <= -heightMax[i])
                    if (h<=-max)
                    {
                        once = true;
                        //direction[i] = true;
                    }
                }

                Vector3 pos = new Vector3(-2f + (4 * (i / (float)vertices)), h, 0f);

                line.SetPosition(i, pos);
            }
        //}

        //for(int i= vertices-1; i>=0; i--)
        //{
        //    Vector3 position;
        //    float height;
        //    if (i != 0)
        //    {
        //        height = line.GetPosition(i - 1).y;
        //    }
        //    else
        //    {
        //        height = heightScale * Mathf.PerlinNoise(Time.time * x, 0.0f);
        //    }
        //    position = new Vector3(1f - (2f * ((i + 1) / (float)vertices)), height, 0);
        //    line.SetPosition(i, position);
        //}
    }
}
