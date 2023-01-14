using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Bloom : MonoBehaviour
{
    public Controller controller;

    public PostProcessVolume pp1;
    public PostProcessVolume pp2;
    private float dif;
    private Bloom bloom;
    private PostProcessVolume volume;

    Camera cam;
    bool zoom;

    void Start()
    {

        dif = controller.minDiffusion;
        pp1.enabled = true;
        pp2.enabled = false;
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {

        if (controller.signal2)
        {
            if (pp1.isActiveAndEnabled)
            {
                pp2.enabled = true;
                pp1.enabled = false;

            }
            else
            {
                pp1.enabled = true;
                pp2.enabled = false;

            }
        }
    }

}

