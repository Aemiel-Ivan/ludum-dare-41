using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector2 readyPosition;
    public float positioningDuration;

    protected void SpawnEnemy()
    {
        GameObject enemy = ObjectPool.Instance.GetObject(enemyPrefab);

        enemy.GetComponent<EnemyShootable>()
            .ResetHealth();

        if (positioningDuration > 0)
        {
            enemy.GetComponent<AutomovementBehavior>()
                .Setup(transform.position, readyPosition, positioningDuration);
        }

        SpawnHook(enemy);
    }

    protected abstract void SpawnHook(GameObject enemy);
}
