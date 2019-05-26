using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [SerializeField]
    private GameObject enemyPrefab;

    float spawnNewEnemyTimer = 1f;
    
    void Awake()
    {
        if (instance == null)
            instance = this;        
    }
    void Update()
    {
        spawnNewEnemyTimer -= Time.deltaTime;
        if (spawnNewEnemyTimer <= 0)
        {
            spawnNewEnemyTimer = 10f;
            SpawnEnemy();
            spawnNewEnemyTimer -= 1f;
        }

        
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
