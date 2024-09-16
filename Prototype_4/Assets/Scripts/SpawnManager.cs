using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // gameobject
    public GameObject enemies;
    //private float startDelay = 2.5f;
    //private float repeatRate = 1.5f;
    private float spawnRange = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnEnemies", startDelay, repeatRate);
        Instantiate(enemies, SpawnEnemies(), enemies.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnEnemies();
    }

    private Vector3 SpawnEnemies() 
    {
        float randomPos = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(randomPos, 0, randomPos);

        return spawnPos;
    }
}