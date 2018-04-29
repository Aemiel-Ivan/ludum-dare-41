using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMover : Mover {

    [SerializeField]
    private float moveSpeed;

    private float direction;

    public override void MoverAwake(Collider2D collider, Animator animator)
    {
    }

    public override void MoverUpdate()
    {
        float rawDir = Input.GetAxis("Vertical");
        int newDir = (int)(rawDir == 0 ? 0 : Mathf.Sign(rawDir));

        if (direction != newDir)
        {
            direction = newDir;
        }
    }

    public override Vector2 MoverFixedUpdate()
    {
        Vector2 positionDelta = Vector2.up * (direction * moveSpeed * Time.fixedDeltaTime);
        return positionDelta;
    }

    public override void Reset()
    {
    }
}
