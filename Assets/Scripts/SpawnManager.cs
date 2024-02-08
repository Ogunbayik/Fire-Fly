using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private int maxSpawnCount;
    [SerializeField] private float maxSpawnTimer;
    [Header("Border Settings")]
    [SerializeField] private float xRange;
    [SerializeField] private float yRange;
    private Vector3 randomPosition;

    private int spawnCount;
    private float spawnTimer;
    void Start()
    {
        spawnTimer = maxSpawnTimer;
    }

    void Update()
    {
        StartEnemySpawning();
    }

    private void StartEnemySpawning()
    {
        if (spawnCount < maxSpawnCount)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                spawnCount++;
                CreateEnemy();
                spawnTimer = maxSpawnTimer;
            }
        }
        else
        {
            spawnTimer = maxSpawnTimer;
        }
    }

    private void CreateEnemy()
    {
        var enemy = Instantiate(spawnObject);
        enemy.transform.position = GetRandomPosition();
    }

    private Vector3 GetRandomPosition()
    {
        var spawnPositionZ = 70f;
        var randomX = Random.Range(-xRange, xRange);
        var randomY = Random.Range(1, yRange);

        randomPosition = new Vector3(randomX, randomY, spawnPositionZ);
        return randomPosition;
    }
}
