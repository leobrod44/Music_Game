using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Vector3 nextMoveDir;

    public Controller controller;
    public float dashDistance;
    public ParticleSystem parts;
    Vector3 previousPos;
    public CharacterController c;
    Camera cam;
    Vector3 hitPosition;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        nextMoveDir = new Vector3(x, 0, z);

        if (controller.signal1)
        {
            previousPos = transform.position;
            transform.position = transform.position + nextMoveDir * dashDistance;
            Vector3 rot = previousPos - transform.position;
            cam.fieldOfView -= 10;
            cam.fieldOfView += 10;

        }
        

    }
}
