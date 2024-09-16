using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // gameobject
    public GameObject enemies;
    public GameObject powerUpPrefabs;
    //private float startDelay = 2.5f;
    //private float repeatRate = 1.5f;
    private float spawnRange = 6.0f;

    [SerializeField]
    private int enemyCount;

    [SerializeField]
    private int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnEnemyWave", startDelay, repeatRate);
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefabs, GenerateSpawnPosition(), powerUpPrefabs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // reuturn a list / array of type
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefabs, GenerateSpawnPosition(), powerUpPrefabs.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float randomPos = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(randomPos, 0, randomPos);

        return spawnPos;
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemies, GenerateSpawnPosition(), enemies.transform.rotation);
            Debug.Log("Instantiated " + i + " times");
        }
    }
}