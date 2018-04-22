using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomBlueprintUnit {
    [SerializeField]
    private int startX;

    [SerializeField]
    private int startY;

    [SerializeField]
    private int width;

    [SerializeField]
    private int height;
    
    [SerializeField]
    private string movingFlag;

    [SerializeField]
    private string activeFlag;

    [SerializeField]
    private int moveX;

    [SerializeField]
    private int moveY;

    [SerializeField]
    private float moveSpeed;

    public GameObject construct(GameObject prefab, Transform parent)
    {
        GameObject created = MapCreator.construct(startX, startY, width, height, prefab, parent);

        bool moving = GlobalFlags.IsSet(movingFlag);
        bool active = GlobalFlags.IsSet(activeFlag);

        if (active && moving)
        {
            // TODO
        }

        created.SetActive(active);

        return created;
    }
}
