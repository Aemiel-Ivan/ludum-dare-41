﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFlag : Interactable {

    private string flag;
    private string switchable; 

    public void Setup (string flag, string switchable)
    {
        this.flag = flag;
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