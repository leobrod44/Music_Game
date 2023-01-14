using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int numObstaclesPerSpawn;
    public int numObstacleSpawns;
    public float timebBtwSpawn;
    public float distance;
    public GameObject spawnObj;
    private int[,] obstaclePositions;
    float t;
    int currentCol;
    Vector3 initialPos;
    Vector3 currentPos;
    public Controller controller;
    
    
    void Start()
    {
        obstaclePositions = createMap(numObstacleSpawns, numObstaclesPerSpawn);
        initialPos = new Vector3(transform.position.x - (numObstaclesPerSpawn* distance)/2, transform.position.y, transform.position.z);
        currentCol = 0;
        Debug.Log(initialPos);
        currentPos = initialPos;
        //this changed
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time> t+ timebBtwSpawn)
        {
            for (int i = 0; i < numObstaclesPerSpawn; i++)
            {

                Debug.Log(obstaclePositions[currentCol, i]);
                GameObject clone  = Instantiate(spawnObj, currentPos, Quaternion.identity);
                StartCoroutine(DestroyCube(clone, 6));
                currentPos.x += distance;
                Debug.Log(initialPos);
            }
            currentPos = initialPos;
            currentCol += 1;
            t = Time.time;
            
        }
    }
    public int[,] createMap(int collums, int rows)
    {
        int[,] o = new int[collums, rows];
        for (int i = 0; i < collums; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                int rand = Mathf.RoundToInt(Random.Range(0, 2));
                Debug.Log(rand);
                o[i, j] = rand;
            }
        }
        return o;
    }
    public IEnumerator DestroyCube(GameObject obj, float t)
    {
        yield return new WaitForSeconds(t);
        Destroy(obj);
    }
}
