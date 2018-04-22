using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomBlueprintUnitFlag : RoomBlueprintUnit {

    [SerializeField]
    protected string flag;
	
	public override GameObject construct(GameObject prefab, Transform parent)
    {
        GameObject created = base.construct(prefab, parent);

        PressurePlate pressurePlate = created.GetComponent<PressurePlate>();
        if (pressurePlate != null)
        {
            pressurePlate.Setup(
                flag
                );
        }

        return created;
    }
}
