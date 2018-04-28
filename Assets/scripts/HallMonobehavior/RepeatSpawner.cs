using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatSpawner : Spawner, DeathListener {
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

    protected override void SpawnHook (GameObject enemy)
    {
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
