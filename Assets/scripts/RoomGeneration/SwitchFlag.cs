using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFlag : Interactable {
    
    private string switchable;

    public override void Setup (string flag)
    {
        base.Setup(flag);
        this.switchable = "F";
    }

    public void Setup (string flag, string switchable)
    {
        base.Setup(flag);
        this.switchable = switchable;
    }

    public override void Interact()
    {
        base.Interact();

        if (GlobalFlags.IsSet(switchable))
        {
            GlobalFlags.SetFlag(flag, !GlobalFlags.IsSet(flag));
        }
        else
        {
            GlobalFlags.SetFlag(flag, true);
        }
    }
}
