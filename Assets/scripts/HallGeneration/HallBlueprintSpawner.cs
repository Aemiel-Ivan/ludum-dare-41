using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HallBlueprintSpawner {
    [SerializeField]
    private Vector2 initialPosition;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private Vector2 readyPosition;

    [SerializeField]
    private float positioningDuration;

    [SerializeField]
    private float spawnRest;

    [SerializeField]
    private int spawnCap;

    private static GameObject spawnerPrefab;
    private static GameObject SpawnerPrefab
    {
        get
        {
            if (spawnerPrefab == null)
            {
                spawnerPrefab = Resources.Load<GameObject>("prefabs/shooter/spawner");
            }

            return spawnerPrefab;
        }
    }

    public GameObject Spawn(Transform parent)
    {
        GameObject unit = GameObject.Instantiate(SpawnerPrefab, parent);
        Spawner spawner = unit.GetComponent<Spawner>();
        spawner.enemyPrefab = enemyPrefab;
        spawner.readyPosition = readyPosition;
        spawner.positioningDuration = positioningDuration;
        spawner.spawnRest = spawnRest;
        spawner.spawnCap = spawnCap;
        unit.transform.position = new Vector3(
            initialPosition.x,
            initialPosition.y,
            enemyPrefab.transform.position.z
            );
        return unit;
    }
}
