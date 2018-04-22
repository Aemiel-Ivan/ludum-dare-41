using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomBlueprintUnitDynamic : RoomBlueprintUnit {

    [SerializeField]
    protected string movingFlag;

    [SerializeField]
    protected string activeFlag;

    [SerializeField]
    protected Vector2 movement;

    [SerializeField]
    protected float moveSpeed;

    public override GameObject construct(GameObject prefab, Transform parent)
    {
        GameObject created = base.construct(prefab, parent);

        RoomUnit unit = created.GetComponent<RoomUnit>();
        unit.Setup(
            movingFlag,
            activeFlag,
            moveSpeed,
            created.transform.position,
            created.transform.position + (Vector3)movement
            );

        return created;
    }
}
