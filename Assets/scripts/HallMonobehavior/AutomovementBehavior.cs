using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AutomovementBehavior : MonoBehaviour {

    private Rigidbody2D rbody;
    
    private Vector2 readyPosition;
    private float positioningSpeed;
    private bool positioned = true;

    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    public void Setup(Vector2 initialPosition, Vector2 readyPosition, float positioningDuration)
    {
        rbody.MovePosition(initialPosition);
        this.readyPosition = readyPosition;
        this.positioningSpeed = (readyPosition - initialPosition).magnitude / positioningDuration;
        this.positioned = false;
    }

    void FixedUpdate ()
    {
		if (positioned)
        {
            float displacement = positioningSpeed * Time.deltaTime;
            Vector2 nextPosition = Vector2.MoveTowards(rbody.position, readyPosition, displacement);
            rbody.MovePosition(nextPosition);

            if (rbody.position == readyPosition)
            {
                positioned = true;
            }
        }
        else
        {
            Move();
        }
	}

   protected abstract void Move();
}
