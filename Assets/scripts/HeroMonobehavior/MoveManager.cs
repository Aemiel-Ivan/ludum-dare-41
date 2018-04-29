using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour {
    List<MovementDecorator> decorators;
    List<Mover> movers;
    Rigidbody2D rbody;
    Animator animator;
    bool facingRight;
    
	void Awake () {
        this.decorators = new List<MovementDecorator>(GetComponents<MovementDecorator>());
        this.decorators.Sort((x, y) => x.order.CompareTo(y.order));
        this.movers = new List<Mover>(GetComponents<Mover>());
        this.rbody = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.facingRight = false;

        Collider2D collider = GetComponent<Collider2D>();
        foreach (Mover mover in movers)
        {
            mover.MoverAwake(collider, animator);
        }
	}
	
	void Update () {
        foreach (Mover mover in movers)
        {
            mover.MoverUpdate();
        }
	}

    void FixedUpdate()
    {
        Vector2 movement = Vector2.zero;

        foreach (Mover mover in movers)
        {
            Vector2 delta = mover.MoverFixedUpdate();
            movement += delta;
        }
        
        foreach (MovementDecorator decorator in decorators)
        {
            movement = decorator.Decorate(movement);
        }

        bool newFacingRight = movement.x > 0;
        if (movement.x != 0 && newFacingRight != facingRight)
        {
            Flip();
        }

        rbody.MovePosition(rbody.position + movement);
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(
            -transform.localScale.x,
            transform.localScale.y,
            transform.localScale.z
            );
    }

    public void Reset()
    {
        foreach (Mover mover in movers)
        {
            mover.Reset();
        }
    }
}
