using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faller : Mover
{
    [SerializeField]
    protected float raycastOffset;

    [SerializeField]
    protected float widthOffset;

    [SerializeField]
    protected bool grounded;

    protected float raycastDist;
    protected int platformLayer;
    protected float checkingWidth;

    protected Collider2D collider;
    protected Animator animator;

    protected float gravityDesc;
    protected float currentVelocity;


    public override void MoverAwake(Collider2D collider, Animator animator)
    {
        this.collider = collider;
        this.animator = animator;
        this.platformLayer = LayerMask.NameToLayer("Platform");

        this.raycastDist = this.collider.bounds.extents.y + raycastOffset;
        this.checkingWidth = collider.bounds.size.x + widthOffset;
        this.grounded = false;
    }

    public override void MoverUpdate()
    {
    }

    public override Vector2 MoverFixedUpdate()
    {
        UpdateGrounded(3);
        animator.SetBool("Grounded", this.grounded);

        if (grounded)
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

    protected void UpdateGrounded(int points)
    {
        Vector2 baseSource = (Vector2)transform.position + collider.offset;

        if (points <= 1)
        {
            this.grounded = Physics2D.Raycast(
                baseSource,
                Vector2.down,
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
            this.grounded = Physics2D.Raycast(
                source,
                Vector2.down,
                raycastDist,
                1 << platformLayer
            );

            if (this.grounded)
            {
                return;
            }
        }

        this.grounded = false;
    }
}
