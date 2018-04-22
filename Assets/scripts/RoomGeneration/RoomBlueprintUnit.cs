using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomBlueprintUnit {
    [SerializeField]
    protected int startX;

    [SerializeField]
    protected int startY;

    [SerializeField]
    protected int width;

    [SerializeField]
    protected int height;
    
    [SerializeField]
    protected string movingFlag;

    [SerializeField]
    protected string activeFlag;

    [SerializeField]
    protected int moveX;

    [SerializeField]
    protected int moveY;

    [SerializeField]
    protected float moveSpeed;

    public virtual GameObject construct(GameObject prefab, Transform parent)
    {
        GameObject created = MapCreator.construct(startX, startY, width, height, prefab, parent);

        RoomUnit unit = created.GetComponent<RoomUnit>();
        unit.Setup(
            movingFlag,
            activeFlag,
            moveSpeed,
            created.transform.position,
            created.transform.position + new Vector3(moveX, moveY)
            );

        return created;
    }
}
