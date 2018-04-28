using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterRotational : Shooter
{
    [SerializeField]
    private Vector2 direction;

    [SerializeField]
    private float deltaDegrees;

    [SerializeField]
    private int bulletCount;

    protected override List<Vector2> GetDirections()
    {
        List<Vector2> directions = new List<Vector2>();

        for (int i = 0; i < bulletCount; i++)
        {
            directions.Add(Quaternion.Euler(0, 0, deltaDegrees * i) * direction);
        }

        direction = Quaternion.Euler(0, 0, deltaDegrees) * direction;

        return directions;
    }
}
