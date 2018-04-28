using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCircular : Shooter {

    [SerializeField]
    private int bulletCount;

    protected override List<Vector2> GetDirections()
    {
        float deltaDegrees = 360f / bulletCount;
        List<Vector2> directions = new List<Vector2>();

        for (int i = 0; i < bulletCount; i++)
        {
            directions.Add(Quaternion.Euler(0, 0, deltaDegrees * i) * Vector2.down);
        }

        return directions;
    }
}
