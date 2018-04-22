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

    [SerializeField]
    private bool touchingCeil;


    public override void MoverAwake (Collider2D collider, Animator animator)
    {
        base.MoverAwake(collider, animator);
        this.collider = collider;
        this.animator = animator;

        this.gravityDesc = (2 * jumpHeight) / (hangTime * hangTime);
        this.jumpVelocity = gravityDesc * hangTime;
        this.jump = false;
        this.touchingCeil = false;
    }

    public override void MoverUpdate ()
    {
        base.MoverUpdate();

        this.jump = Input.GetKey(KeyCode.UpArrow);
    }

    public override Vector2 MoverFixedUpdate()
    {
        UpdateGrounded(3);
        UpdateTouchCeil(3);

        animator.SetBool("Grounded", this.grounded);

        if (grounded)
        {
            currentVelocity = jump ? jumpVelocity : 0;
            jump = false;
        }

        if (touchingCeil && currentVelocity > 0)
        {
            currentVelocity = 0;
        }

        float vDisplacement = currentVelocity * Time.fixedDeltaTime;

        if (!grounded)
        {
            currentVelocity -= (gravityDesc * Time.fixedDeltaTime);
        }

        return (Vector2.up * vDisplacement);
    }

    protected void UpdateTouchCeil (int points)
    {
        Vector2 baseSource = (Vector2)transform.position + collider.offset;

        if (points <= 1)
        {
            this.touchingCeil = Physics2D.Raycast(
                baseSource,
                Vector2.up,
                raycastDist,
                1 << platformLayer
            );

            return;
        }

        float limitX = baseSource.x + checkingWidth / 2;
        float interval = checkingWidth / (points - 1);
        Vector2 basePoint = baseSource - new Vector2(checkingWidth / 2, 0);

        for (Vector2 source = basePoint; source.x <= limitX; source.x += interval)
        {
            this.touchingCeil = Physics2D.Raycast(
                source,
                Vector2.up,
                raycastDist,
                1 << platformLayer
            );

            if (this.touchingCeil)
            {
                return;
            }
        }

        this.touchingCeil = false;
    }
}
