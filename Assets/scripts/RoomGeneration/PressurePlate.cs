using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Interactable {

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Faller faller = collider.gameObject.GetComponent<Faller>();
        if ( faller != null && faller.gameObject.tag != "Blockee")
        {
            GlobalFlags.SetFlag(flag, true);
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        Faller faller = collider.gameObject.GetComponent<Faller>();
        if (faller != null && faller.gameObject.tag != "Blockee")
        {
            GlobalFlags.SetFlag(flag, false);
        }
    }
}
