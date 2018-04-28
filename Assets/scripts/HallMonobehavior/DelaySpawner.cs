using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelaySpawner : Spawner
{
    public float delay;

    private void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            SpawnEnemy();
        }
    }

    protected override void SpawnHook(GameObject enemy)
    {
        DestroyObject(gameObject);
    }
}
