using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable {

    public override void Interact()
    {
        base.Interact();

        if (GlobalFlags.IsSet(flag))
        {
            Debug.Log("OPEN DOOR!");
        }
    }
}
