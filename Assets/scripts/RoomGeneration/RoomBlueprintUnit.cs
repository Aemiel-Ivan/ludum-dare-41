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
