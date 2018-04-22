using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faller : Mover
{
    [SerializeField]
    protected float fallHeight;

    [SerializeField]
    protected float hangTime;

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
    protected Rigidbody2D rbody;

    protected float gravityDesc;
    protected float currentVelocity;
    protected RoomUnit footing;

    public override void MoverAwake(Collider2D collider, Animator animator)
    {
        this.collider = collider;
        this.animator = animator;
        this.gravityDesc = (2 * fallHeight) / (hangTime * hangTime);
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

        float vDisplacement = currentVelocity * Time.fixedDeltaTime;

        if (!grounded)
        {
            currentVelocity -= (gravityDesc * Time.fixedDeltaTime);
        }
        else
        {
            currentVelocity = 0;
        }

        Vector2 posDelta = (Vector2.up * vDisplacement);

        return posDelta;
    }

    private void setGrounded (RaycastHit2D hit)
    {
        this.grounded = (hit != false && hit.transform != transform);
        
        if (this.grounded)
        {
            footing = hit.transform.GetComponent<RoomUnit>();
            transform.SetParent(footing.transform);
        }
        else if (footing != null)
        {
            footing = null;
            transform.SetParent(transform.root);
        }
    }

    protected void UpdateGrounded(int points)
    {
        Vector2 baseSource = (Vector2)transform.position + collider.offset;

        if (points <= 1)
        {
            RaycastHit2D hit = Physics2D.Raycast(
                baseSource,
                Vector2.down,
                raycastDist,
                1 << platformLayer
            );

            setGrounded(hit);

            return;
        }

        float limitX = baseSource.x + checkingWidth / 2;
        float interval = checkingWidth / (points - 1);
        Vector2 basePoint = baseSource - new Vector2(checkingWidth / 2, 0);

        for (Vector2 source = basePoint; source.x <= limitX; source.x += interval)
        {
            RaycastHit2D hit = Physics2D.Raycast(
                source,
                Vector2.down,
                raycastDist,
                1 << platformLayer
            );

            setGrounded(hit);

            if (this.grounded)
            {
                return;
            }
        }

        this.grounded = false;
        if (footing != null)
        {
            footing = null;
            transform.SetParent(transform.root);
        }
    }
}
