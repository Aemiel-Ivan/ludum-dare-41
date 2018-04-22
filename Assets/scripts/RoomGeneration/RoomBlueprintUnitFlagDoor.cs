using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomBlueprintUnitFlagDoor : RoomBlueprintUnitFlag
{
    [SerializeField]
    protected string room;

    public override GameObject construct(GameObject prefab, Transform parent)
    {
        GameObject created = base.construct(prefab, parent);

        Door door = created.GetComponent<Door>();
        if (door != null)
        {
            door.Setup(
                flag,
                room
                );
        }

        return created;
    }
}
