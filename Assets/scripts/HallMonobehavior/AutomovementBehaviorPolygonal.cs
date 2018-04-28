using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomovementBehaviorPolygonal : AutomovementBehavior
{
    [SerializeField]
    private List<Vector2> directions;

    [SerializeField]
    private float period;

    private float speed;
    private List<Vector2> iteneraries;
    private int currentItenerary;
    
    protected override void SetupHook()
    {
        rbody = GetComponent<Rigidbody2D>();
        iteneraries = new List<Vector2>();

        iteneraries.Add(readyPosition);
        for (int i = 0; i < directions.Count; i++)
        {
            iteneraries.Add(iteneraries[i] + directions[i]);
        }

        float totalDistance = 0;
        for (int i = 0; i < iteneraries.Count; i++)
        {
            totalDistance += (iteneraries[(i+1)%iteneraries.Count] - iteneraries[i]).magnitude;
        }

        speed = totalDistance / period;
        currentItenerary = 1;
    }

    protected override void Move()
    {
        float displacement = speed * Time.fixedDeltaTime;
        Vector2 goal = iteneraries[currentItenerary];
        Vector2 nextPosition = Vector2.MoveTowards(rbody.position, iteneraries[currentItenerary], displacement);
        rbody.MovePosition(nextPosition);

        if (nextPosition == goal)
        {
            currentItenerary = (currentItenerary + 1) % iteneraries.Count;
        }
    }
}
