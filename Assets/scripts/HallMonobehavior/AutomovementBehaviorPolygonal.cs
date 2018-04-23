using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomovementBehaviorPolygonal : AutomovementBehavior
{
    [SerializeField]
    private List<Vector2> iteneraries;

    [SerializeField]
    private float period;

    private float speed;
    private int currentItenerary = 0;
    
    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();

        float totalDistance = 0;
        for (int i = 0; i < iteneraries.Count; i++)
        {
            totalDistance += (iteneraries[(i+1)%iteneraries.Count] - iteneraries[i]).magnitude;
        }

        speed = totalDistance / period;
        currentItenerary = 0;
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
