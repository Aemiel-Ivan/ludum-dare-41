using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HallBlueprintEnemy {
    [SerializeField]
    private Vector2 initialPosition;

    [SerializeField]
    private GameObject enemyPrefab;
    
    [SerializeField]
    private Vector2 readyPosition;

    [SerializeField]
    private float positioningDuration;
    
    public GameObject Spawn (Transform parent)
    {
        GameObject enemy = GameObject.Instantiate(enemyPrefab, parent);

        if (positioningDuration > 0)
        {
            enemy.GetComponent<AutomovementBehavior>()
                .Setup(initialPosition, readyPosition, positioningDuration);
        }

        return enemy;
    }
}
