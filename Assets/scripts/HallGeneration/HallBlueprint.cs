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
    List<HallBlueprintSpawner> spawners;

    public void Construct (GameObject map)
    {
        GameObject.FindGameObjectWithTag("Blockee")
            .transform.position = blockeeInitialPosition;

        foreach (HallBlueprintEnemy enemy in enemies)
        {
            enemy.Spawn(map.transform);
        }

        foreach (HallBlueprintSpawner spawner in spawners)
        {
            spawner.Spawn(map.transform);
        }
    }

}
