using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    protected string flag;

    public virtual void Setup(string flag)
    {
        this.flag = flag;
    }

    public virtual void Interact()
    {
        
    }
}
