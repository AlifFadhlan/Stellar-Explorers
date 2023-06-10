using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;


    // private float spawnRangeY = 10;
    private float spawnYMin = 1; // set min spawn Y
    private float spawnYMax = 8.5f; // set max spawn Y
    public float spawnZMin = 30; // set min spawn Z
    public float spawnZMax = 40; // set max spawn Z

    private float spawnXMin = -4.5f; // set min spawn Y
    private float spawnXMax = 3.5f; // set max spawn Y

    public int enemyCount;
    public int waveCount = 1;
    public float enemySpeed = 10f;
    public float enemiesToSpawn = 1;

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Obstacle").Length;

        if (enemyCount == 0)
        {
            SpawnEnemyWave();
        }

    }
    Vector3 GenerateSpawnPosition ()
    {
        float zPos = Random.Range(spawnZMin, spawnZMax);
        float xPos = Random.Range(spawnXMin, spawnXMax);
        float yPos = Random.Range(spawnYMin, spawnYMax);
        return new Vector3(xPos, yPos, zPos);
    }

    void SpawnEnemyWave()
    {
        // Spawn number of enemy balls based on wave number
        
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randomIndex = Random.Range(0, obstaclePrefab.Length);
        Instantiate(obstaclePrefab[randomIndex], GenerateSpawnPosition(), obstaclePrefab[randomIndex].transform.rotation);
        }

        // enemySpeed += 15;

    }
    


}
