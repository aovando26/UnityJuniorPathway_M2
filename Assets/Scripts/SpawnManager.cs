using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(20, 0, 0);
    public float startDelay = 2.0f;
    public float repeatDelay = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefabs, spawnPos, transform.rotation);
    }
}
