using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    private string flag;

	public void Setup (string flag)
    {
        this.flag = flag;
    }

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
