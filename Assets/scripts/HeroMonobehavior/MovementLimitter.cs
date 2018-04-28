using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLimitter : MovementDecorator {
    [SerializeField]
    private float speedLimit;

    public override Vector2 Decorate(Vector2 displacement)
    {
        return displacement.normalized * speedLimit * Time.fixedDeltaTime;
    }
}
