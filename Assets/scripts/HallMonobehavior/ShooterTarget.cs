using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterTarget : Shooter {
    private static GameObject hero;
    private static GameObject Hero
    {
        get
        {
            if (hero == null)
            {
                hero = GameObject.FindGameObjectWithTag("Blockee");
            }

            return hero;
        }
    }

    [SerializeField]
    private int bulletCount;

    [SerializeField]
    private float degreesRange;

    protected override List<Vector2> GetDirections()
    {
        List<Vector2> directions = new List<Vector2>();
        Vector2 targetDirection = Hero.transform.position - transform.position;
        
        if (bulletCount <= 1)
        {
            directions.Add(targetDirection);
            return directions;
        }

        Vector2 baseDirection = Quaternion.Euler(0, 0, -degreesRange/2) * targetDirection;
        float degreesSpread = degreesRange / (bulletCount - 1);

        for (int i = 0; i < bulletCount; i++)
        {
            Vector2 direction = Quaternion.Euler(0, 0, degreesSpread * i) * baseDirection;
            directions.Add(direction);
        }

        return directions;
    }
}
