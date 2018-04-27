using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, DeathListener {
    public GameObject enemyPrefab;
    public Vector2 readyPosition;
    public float positioningDuration;
    public float spawnRest;
    public int spawnCap;

    private float restToSpawn;
    private int livingSpawn;

    void Update()
    {
        if (spawnCap <= 0 || livingSpawn < spawnCap)
        {
            restToSpawn -= Time.deltaTime;
            if (restToSpawn <= 0)
            {
                restToSpawn += spawnRest;
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy ()
    {
        GameObject enemy = ObjectPool.Instance.GetObject(enemyPrefab);

        enemy.GetComponent<EnemyShootable>()
            .ResetHealth();

        if (positioningDuration > 0)
        {
            enemy.GetComponent<AutomovementBehavior>()
                .Setup(transform.position, readyPosition, positioningDuration);
        }

        if (spawnCap > 0)
        {
            livingSpawn++;
            enemy.GetComponent<DeathEmitter>().Subscribe(this);
        }
    }

    public void Notify(DeathEmitter d)
    {
        if (spawnCap > 0)
        {
            livingSpawn--;
        }
    }
}
