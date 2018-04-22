using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomBlueprintUnitFlagSwitch : RoomBlueprintUnitFlag {
    [SerializeField]
    protected string switchable;

    public override GameObject construct(GameObject prefab, Transform parent)
    {
        GameObject created = base.construct(prefab, parent);

        SwitchFlag switchFlag = created.GetComponent<SwitchFlag>();
        if (switchFlag != null)
        {
            switchFlag.Setup(
                flag,
                switchable
                );
        }

        return created;
    }
}
