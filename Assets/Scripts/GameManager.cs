using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float spawnRange = 7;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }

    public void GameOver()
    {
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
}
