using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHalferHero : MovementDecorator {
    public override Vector2 Decorate(Vector2 displacement)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return displacement / 2;
        }

        return displacement;
    }
}
