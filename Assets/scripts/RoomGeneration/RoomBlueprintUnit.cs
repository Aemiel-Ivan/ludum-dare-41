using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomBlueprintUnit {
    [SerializeField]
    protected Vector2 startPosition;

    [SerializeField]
    protected Vector2 dimensions;

    public virtual GameObject construct(GameObject prefab, Transform parent)
    {
        GameObject created = MapCreator.construct(startPosition, dimensions, prefab, parent);

        return created;
    }
}
