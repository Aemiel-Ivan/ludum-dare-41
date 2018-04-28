using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementDecorator : MonoBehaviour {
    public int order;
    public abstract Vector2 Decorate(Vector2 displacement);
}
