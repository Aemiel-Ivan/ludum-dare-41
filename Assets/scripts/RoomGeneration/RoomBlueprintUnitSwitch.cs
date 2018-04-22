using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomBlueprintUnitSwitch : RoomBlueprintUnit {
    [SerializeField]
    private string switchable;

    [SerializeField]
    private string flag;

    public override GameObject construct(GameObject prefab, Transform parent)
    {
        GameObject created = base.construct(prefab, parent);

        SwitchFlag switchFlag = created.GetComponent<SwitchFlag>();
        switchFlag.Setup(
            this.flag,
            this.switchable
            );

        return created;
    }
}
