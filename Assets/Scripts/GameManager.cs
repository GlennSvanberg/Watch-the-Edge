using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float spawnRange = 6;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public GameObject titleScreen;
    public bool gameIsActive = false;
    private int score;
    public int difficulty;
    public TextMeshProUGUI scoreText;



    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (gameIsActive)
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;
            if (enemyCount == 0)
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
                SpawnPowerup();
            }
        }
        }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameIsActive = false;
        RestartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPos(), powerupPrefab.transform.rotation);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0.5f, spawnPosY);
    }
    public void StartGame(int d)
    {
        difficulty = d;
        gameIsActive = true;
        titleScreen.SetActive(false);
        SpawnEnemyWave(waveNumber);
    }
}
