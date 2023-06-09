using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public GameObject raykiri;
    public GameObject raykanan;

    [Header("Main Menu Buttons")]
    public GameObject mainMenu;
    public GameObject gameOverMenu;
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;
    public Button restartButton;
    public Button backToMenu;

    public Score scoreScript;

    public ParticleSystem particleEffect;


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


    public bool isGameActive = false;

    void Start()
    {
        mainMenu.SetActive(true);
        // Hook events
        easyButton.onClick.AddListener(EasyGame);
        mediumButton.onClick.AddListener(MediumGame);
        hardButton.onClick.AddListener(HardGame);
        restartButton.onClick.AddListener(RestartGame);
        backToMenu.onClick.AddListener(BackToMenu);
    }

    public void RestartGame()
    {
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(true);

    }

    public void EasyGame()
    {
        isGameActive = true;
        particleEffect.Play();
        mainMenu.SetActive(false);
        enemySpeed = 10f;
        enemiesToSpawn = 2;
        Update();
        scoreScript.StartScore();
        raykiri.SetActive(false);
        raykanan.SetActive(false);
        
    }
    public void MediumGame()
    {
        isGameActive = true;
        particleEffect.Play();
        mainMenu.SetActive(false);
        enemySpeed = 10f;
        enemiesToSpawn = 3;
        Update();
        scoreScript.StartScore();
        raykiri.SetActive(false);
        raykanan.SetActive(false);
        
    }
    public void HardGame()
    {
        isGameActive = true;
        particleEffect.Play();
        mainMenu.SetActive(false);
        enemySpeed = 15f;
        enemiesToSpawn = 4;
        Update();
        scoreScript.StartScore();
        raykiri.SetActive(false);
        raykanan.SetActive(false);
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartScene");
    }


    // public void GamePlay()
    // {
    //     enemyCount = GameObject.FindGameObjectsWithTag("Obstacle").Length;

    //     if (enemyCount == 0)
    //     {
    //         SpawnEnemyWave();
    //     }
    // }
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

    public void GameOver(){
        isGameActive = false;
        particleEffect.Stop();
        scoreScript.StopScore();
        scoreScript.UpdateHighscore();
        scoreScript.score = 0; // Mengatur ulang skor menjadi 0
        scoreScript.scoreText.text = "0"; // Menampilkan skor 0 di UI
        gameOverMenu.SetActive(true);
        raykiri.SetActive(true);
        raykanan.SetActive(true);
        enemiesToSpawn=0;
    }
    


}
