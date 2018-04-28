using UnityEngine;

[System.Serializable]
public class RoomBlueprintUnitFlagDoor : RoomBlueprintUnitFlag
{
    [SerializeField]
    protected string room;

    [SerializeField]
    protected string alternateRoom;

    public override GameObject construct(GameObject prefab, Transform parent)
    {
        GameObject created = base.construct(prefab, parent);

        Door[] doors = created.GetComponents<Door>();
        foreach (Door door in doors)
        {
            if (door.IsAlternate)
            {
                door.Setup(flag,
                    alternateRoom);
            }
            else
            {
                door.Setup(flag,
                    room);
            }
        }

        return created;
    }
}
