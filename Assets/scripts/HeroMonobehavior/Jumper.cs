using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : Faller {

    [SerializeField]
    private float jumpHeight;

    [SerializeField]
    private float hangTime;

    private Collider2D collider;
    private Animator animator;

    private bool jump;
    private float jumpVelocity;


    public override void MoverAwake (Collider2D collider, Animator animator)
    {
        base.MoverAwake(collider, animator);
        this.collider = collider;
        this.animator = animator;

        this.gravityDesc = (2 * jumpHeight) / (hangTime * hangTime);
        this.jumpVelocity = gravityDesc * hangTime;
        this.jump = false;
    }

    public override void MoverUpdate ()
    {
        base.MoverUpdate();

        this.jump = Input.GetKey(KeyCode.UpArrow);
    }

    public override Vector2 MoverFixedUpdate()
    {
        UpdateGrounded(3);
        animator.SetBool("Grounded", this.grounded);
        
        if (grounded)
        {
            currentVelocity = jump ? jumpVelocity : 0;
            jump = false;
        }

        float vDisplacement = currentVelocity * Time.fixedDeltaTime;

        if (!grounded)
        {
            currentVelocity -= (gravityDesc * Time.fixedDeltaTime);
        }

        return (Vector2.up * vDisplacement);
    }
}
