using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private float spawnRangeY = 10;
    private float spawnZMin = -13; // set min spawn Z
    private float spawnZMax = -4; // set max spawn Z

    private float spawnXMin = -5; // set min spawn Y
    private float spawnXMax = 3.7f; // set max spawn Y

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
        return new Vector3(xPos, spawnRangeY, zPos);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        // Spawn number of enemy balls based on wave number
    
        
            Instantiate(obstaclePrefab, GenerateSpawnPosition(), obstaclePrefab.transform.rotation);
        

        enemySpeed += 15;

    }


}
