using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private float spawnRangeY = 10;
    private float spawnYMin = 1; // set min spawn Y
    private float spawnYMax = 8.5f; // set max spawn Y
    private float spawnZMin = 15; // set min spawn Z
    private float spawnZMax = 25; // set max spawn Z

    private float spawnXMin = -4.5f; // set min spawn Y
    private float spawnXMax = 3.5f; // set max spawn Y

    public int enemyCount;
    public int waveCount = 1;
    public float enemySpeed = 10f;

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Obstacle").Length;

        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveCount);
        }

    }
    Vector3 GenerateSpawnPosition ()
    {
        float zPos = Random.Range(spawnZMin, spawnZMax);
        float xPos = Random.Range(spawnXMin, spawnXMax);
        float yPos = Random.Range(spawnYMin, spawnYMax);
        return new Vector3(xPos, yPos, zPos);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        // Spawn number of enemy balls based on wave number
    
        for (int i = 0; i < 2; i++)
        {
        Instantiate(obstaclePrefab, GenerateSpawnPosition(), obstaclePrefab.transform.rotation);
        }

        // enemySpeed += 15;

    }


}
