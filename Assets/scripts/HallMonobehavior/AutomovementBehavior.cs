using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AutomovementBehavior : MonoBehaviour {

    protected Rigidbody2D rbody;
    
    protected Vector2 readyPosition;
    private float positioningSpeed;
    private bool positioned = true;

    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    public void Setup(Vector2 initialPosition, Vector2 readyPosition, float positioningDuration)
    {
        transform.position = initialPosition;
        this.readyPosition = readyPosition;
        this.positioningSpeed = (readyPosition - initialPosition).magnitude / positioningDuration;
        this.positioned = false;
        SetupHook();
    }

    protected virtual void SetupHook()
    {
    }

    void FixedUpdate ()
    {
		if (positioned)
        {
            Move();
        }
        else
        {
            float displacement = positioningSpeed * Time.fixedDeltaTime;
            Vector2 nextPosition = Vector2.MoveTowards(rbody.position, readyPosition, displacement);
            rbody.MovePosition(nextPosition);

            if (rbody.position == readyPosition)
            {
                positioned = true;
            }
        }
	}

   protected abstract void Move();
}
