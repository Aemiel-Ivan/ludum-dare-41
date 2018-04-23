using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HallBlueprint : ScriptableObject {

    [SerializeField]
    Vector2 blockeeInitialPosition;

    [SerializeField]
    List<HallBlueprintEnemy> enemies;

    void OnEnable()
    {
        GameObject.FindGameObjectWithTag("Blockee")
            .GetComponent<Rigidbody2D>()
            .MovePosition(blockeeInitialPosition);
    }

    public void Construct (GameObject map)
    {
        foreach (HallBlueprintEnemy enemy in enemies)
        {
            enemy.Spawn(map.transform);
        }
    }

}
