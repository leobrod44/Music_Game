using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float turnSpeed;
    public float distance;
    public int collums;
    public Transform startPos1;
    public Transform startPos2;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public Color a;
    public Color b;
    private Color lasCol;
    bool randomColors;
    public float timeBtwnSpawn;
    float time;
    int currentCol;
    float currentDist;
    void Start()
    {
        currentCol = 0;
        currentDist = 0;
        lasCol = a;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, -turnSpeed * Time.deltaTime);

        if(Time.time > time + timeBtwnSpawn)
        {
            if (currentCol > collums)
            {
                currentCol = 0;
                currentDist = 0;
            }
            for (int j = 0; j < collums; j++)
            {
                Spawn(cube1, new Vector3(startPos1.position.x - currentDist, startPos1.position.y, startPos1.position.z), lasCol);
                Spawn(cube2, new Vector3(startPos2.position.x + currentDist, startPos2.position.y, startPos2.position.z), lasCol);
                lasCol = lasCol == a ? b : a;
            }
            time = Time.time;
        }
    }
    void Spawn(GameObject cube, Vector3 pos, Color c)
    {
        GameObject clone = Instantiate(cube, pos, Quaternion.identity);
        Renderer rend = clone.GetComponent<Renderer>();
        rend.material.SetColor("_Color", c*1);
        rend.material.SetColor("_EmissionColor", c*1);
        currentCol += 1;
        currentDist += distance;
        StartCoroutine(DestroyCube(clone, 6));

        
    }
    public IEnumerator DestroyCube(GameObject obj, float t)
    {
        yield return new WaitForSeconds(t);
        Destroy(obj);
    }

}
