using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomBlueprintUnit {
    [SerializeField]
    protected Vector2 startPosition;

    [SerializeField]
    protected Vector2 dimensions;
    
    [SerializeField]
    protected string movingFlag;

    [SerializeField]
    protected string activeFlag;

    [SerializeField]
    protected Vector2 movement;

    [SerializeField]
    protected float moveSpeed;

    public virtual GameObject construct(GameObject prefab, Transform parent)
    {
        GameObject created = MapCreator.construct(startPosition, dimensions, prefab, parent);

        RoomUnit unit = created.GetComponent<RoomUnit>();
        unit.Setup(
            movingFlag,
            activeFlag,
            moveSpeed,
            created.transform.position,
            created.transform.position + (Vector3) movement
            );

        return created;
    }
}
