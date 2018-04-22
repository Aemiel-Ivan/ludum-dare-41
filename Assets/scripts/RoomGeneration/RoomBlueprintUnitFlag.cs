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

        Interactable interactable = created.GetComponent<Interactable>();
        if (interactable != null)
        {
            interactable.Setup(
                flag
                );
        }

        return created;
    }
}
