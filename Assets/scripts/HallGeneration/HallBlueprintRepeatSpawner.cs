using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HallBlueprintRepeatSpawner {
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

    private static GameObject repeatSpawnerPrefab;
    private static GameObject RepeatSpawnerPrefab
    {
        get
        {
            if (repeatSpawnerPrefab == null)
            {
                System.Type[] components = new System.Type[] { typeof(RepeatSpawner) };
                repeatSpawnerPrefab = new GameObject("Repeat Spawner", components);
                repeatSpawnerPrefab.SetActive(false);
                repeatSpawnerPrefab.hideFlags = HideFlags.HideInHierarchy;
            }

            return repeatSpawnerPrefab;
        }
    }

    public GameObject Spawn(Transform parent)
    {
        GameObject unit = GameObject.Instantiate(RepeatSpawnerPrefab, parent);
        unit.SetActive(true);

        RepeatSpawner spawner = unit.GetComponent<RepeatSpawner>();
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
