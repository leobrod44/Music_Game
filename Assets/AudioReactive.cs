using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReactive : MonoBehaviour
{
    public AudioSource source;
    public float step =0.01f;
    public int sampleDataLength =1024;
    private float currentStepTime = 0f;
    public float clipLoudness;
    private float[] clipSampleData;
    public float sizeMult =1;
    
    public float min = 0;
    public float max = 500;
    Color a;
    Color b;
    Color c;
    public GameObject cube;
    public static bool randomColors;
    public static List<Color> colors= new List<Color>()
        {
            new Color32(166, 254, 0, 1),
            new Color32( 0 , 254 , 111, 1 ),
            new Color32( 0 , 201 , 254, 1 ),
            new Color32( 0 , 122 , 254, 1 ),
            new Color32( 60 , 0 , 254, 1 ),
            new Color32( 143 , 0 , 254, 1 ),
            new Color32( 232 , 0 , 254, 1 ),
            new Color32( 254 , 9 , 0, 1 ),
            new Color32( 254 , 161 , 0, 1 ),
            new Color32( 254 , 224 , 0, 1 )
        };
    Renderer rend;
    public float colorChangeRate;
    float t;
    float delta = 0;
    [SerializeField]
    private float intensity = 0.5f;
    public float inversePoint;
    public float inverseMult;
    [SerializeField]
    private float temp;
    void Start()
    {
       
        clipSampleData = new float[sampleDataLength];
        a = colors[Random.Range(0, colors.Count)];
        b = colors[Random.Range(0, colors.Count)];
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", a);
        rend.material.SetColor("_EmissionColor", a);
    }

    // Update is called once per frame
    void Update()
    {
        // deal with object size
        currentStepTime += Time.deltaTime;
        if(currentStepTime> step)
        {
            currentStepTime = 0f;
            source.clip.GetData(clipSampleData, source.timeSamples);
            clipLoudness = 0f;
        }
        foreach(float sample in clipSampleData)
        {
            clipLoudness += Mathf.Abs(sample);
        }
        intensity = clipLoudness;
        intensity = Mathf.Clamp(intensity, 0f, 1f);
        clipLoudness /= sampleDataLength;
        temp = clipLoudness;
        if (clipLoudness > inversePoint)
        {
            clipLoudness *= inverseMult;
            randomColors = true;
        }
        else
        {
            clipLoudness *= sizeMult;
            randomColors = false;
        }
       
        clipLoudness = Mathf.Clamp(clipLoudness, min, max);
        cube.transform.localScale = new Vector3(cube.transform.localScale.x, clipLoudness, cube.transform.localScale.z);
        //deal with object color

        c = Color.Lerp(a, b, delta);
        delta += Time.deltaTime / colorChangeRate;
        if (temp > 0.42f)
        {
            colorChangeRate = 0.2f;
        }
        if (temp < 0.25f)
        {
            colorChangeRate = 2f;
        }
        rend.material.SetColor("_Color", c * intensity);
        rend.material.SetColor("_EmissionColor", c * intensity);

        if (Time.time > t + colorChangeRate)
        {
            delta = 0;
            a = b;
            b = colors[Random.Range(0, colors.Count)];
            t = Time.time;
        }
    }
}

