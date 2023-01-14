using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float bpm;
    public float bps;
    public float maxDiffusion;
    public float minDiffusion;
    public float timeGap;
    private float time=0;
    private float time2=0;
    public bool signal1;
    public bool signal2;
    void Start()
    {
        bps = bpm / 60;
        timeGap = 1 / bps;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > time + timeGap)
        {
            signal1 = true;
            time = Time.time;
        }
        else
        {
            signal1 = false;
        }
        if (Time.time > time2 + timeGap/2)
        {
            signal2 = true;
            time2= Time.time;
        }
        else
        {
            signal2 = false;
        }
    }
}
