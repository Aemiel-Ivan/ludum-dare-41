using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : Mover {

    [SerializeField]
    private float moveSpeed;

    private float direction;
    private Animator animator;

    public override void MoverAwake(Collider2D collider, Animator animator)
    {
        this.animator = animator;
    }

    public override void MoverUpdate()
    {
        float rawDir = Input.GetAxis("Horizontal");
        int newDir = (int) (rawDir == 0 ? 0 : Mathf.Sign(rawDir));

        if (direction != newDir)
        {
            animator.SetInteger("HorizontalDir", newDir);
            direction = newDir;
        }
    }

    public override Vector2 MoverFixedUpdate()
    {
        Vector2 positionDelta = Vector2.right * (direction * moveSpeed * Time.fixedDeltaTime);
        return positionDelta;
    }
}
