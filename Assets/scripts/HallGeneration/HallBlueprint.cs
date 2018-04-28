using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HallBlueprint : ScriptableObject {

    [SerializeField]
    Vector2 blockeeInitialPosition;

    [SerializeField]
    List<HallBlueprintEnemy> enemies;

    [SerializeField]
    List<HallBlueprintRepeatSpawner> repeatSpawners;

    [SerializeField]
    List<HallBlueprintDelaySpawner> delaySpawners;

    public void Construct (GameObject map)
    {
        GameObject.FindGameObjectWithTag("Blockee")
            .transform.position = blockeeInitialPosition;

        foreach (HallBlueprintEnemy enemy in enemies)
        {
            enemy.Spawn(map.transform);
        }

        foreach (HallBlueprintRepeatSpawner spawner in repeatSpawners)
        {
            spawner.Spawn(map.transform);
        }

        foreach (HallBlueprintDelaySpawner spawner in delaySpawners)
        {
            spawner.Spawn(map.transform);
        }
    }

}
