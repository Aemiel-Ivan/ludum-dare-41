using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEmitter : MonoBehaviour {
    private List<DeathListener> listeners;

    void Awake()
    {
        listeners = new List<DeathListener>();
    }

    public void Subscribe (DeathListener d)
    {
        listeners.Add(d);
    }

    public void EmitDeath()
    {
        foreach (DeathListener d in listeners)
        {
            d.Notify(this);
        }
    }

    public void ClearListeners()
    {
        listeners.Clear();
    }
}
