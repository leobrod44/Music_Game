using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    private Controller controller;
    private Transform stickPoint;
    Renderer rend;
    public Color a;
    public Color b;
    Color c;
    public float colorChangeRate;
    float delta;
    float t;
    void Start()
    {
        stickPoint = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            transform.SetParent(collision.gameObject.transform);
        }
 
    }
}
