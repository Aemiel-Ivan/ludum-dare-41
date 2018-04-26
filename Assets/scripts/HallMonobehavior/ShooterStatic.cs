using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterStatic : Shooter {
    [SerializeField]
    private List<Vector2> directions;

    protected override List<Vector2> GetDirections()
    {
        return directions;
    }
}
