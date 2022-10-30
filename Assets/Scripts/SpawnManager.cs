using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public int enemyCount;
    private int waveNumber = 1;
    public GameObject[] powerUpPrefab;
    public PlayerController player;
    private int randomEnemy;
    private int randomPowerUp;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab[randomPowerUp], GenerateSpawnPos(), powerUpPrefab[randomPowerUp].transform.rotation);
        player =GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0 && !player.gameOver)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab[randomPowerUp], GenerateSpawnPos(), powerUpPrefab[randomPowerUp].transform.rotation);
        } 
    }
    private Vector3 GenerateSpawnPos()
    {
        float randomX = Random.Range(-9, 9);
        float randomZ = Random.Range(-9, 9);
        Vector3 spawnPos = new Vector3(randomX, 0, randomZ);
        return spawnPos;
    }
    void SpawnEnemyWave(int enemyToSpawn)
    {
        randomEnemy = Random.Range(0, 3);
        for (int i = 0; i < enemyToSpawn; i++)
        {
            Instantiate(enemyPrefab[randomEnemy], GenerateSpawnPos(), enemyPrefab[randomEnemy].transform.rotation);
        }
    }
    
}
