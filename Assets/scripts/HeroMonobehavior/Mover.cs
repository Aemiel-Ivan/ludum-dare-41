using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover: MonoBehaviour {
    public abstract void MoverAwake(Collider2D collider, Animator animator);
    public abstract void MoverUpdate();
    public abstract Vector2 MoverFixedUpdate();
    public abstract void Reset();
}
