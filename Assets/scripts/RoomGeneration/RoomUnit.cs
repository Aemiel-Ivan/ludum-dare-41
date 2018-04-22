using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomUnit : MonoBehaviour, FlagSubscriber {

    private string movingFlag;
    private string activeFlag;
    private float moveSpeed;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 targetPos;

    private bool active;
    private bool moving;

    private Collider2D collider;
    private SpriteRenderer renderer;
    private Rigidbody2D rbody;

    private Color activeColor = Color.white;
    private static Color inactiveColor = Color.gray;

	void Awake () {
        collider = GetComponent<Collider2D>();
        renderer = GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
        activeColor = renderer.color;
	}

    void Update ()
    {
        if (moving && active)
        {
            Vector3 nextPos = Vector3.MoveTowards(rbody.position, targetPos, moveSpeed * Time.deltaTime);
            Vector2 posDelta = new Vector2(nextPos.x, nextPos.y) - rbody.position;

            if ((nextPos-targetPos).magnitude < 0.0001)
            {
                targetPos = (targetPos == startPos) ? endPos : startPos;
            }

            // rbody.MovePosition(nextPos);
            transform.position = nextPos;
        }
    }

    public void Setup(string movingFlag, string activeFlag, float moveSpeed, Vector3 startPos, Vector3 endPos)
    {
        this.moveSpeed = moveSpeed;
        this.movingFlag = movingFlag;
        this.activeFlag = activeFlag;
        this.startPos = startPos;
        this.endPos = endPos;
        this.targetPos = endPos;

        GlobalFlags.Subscribe(this, movingFlag);
        GlobalFlags.Subscribe(this, activeFlag);
        
        moving = GlobalFlags.IsSet(movingFlag);

        setActiveFlag(GlobalFlags.IsSet(activeFlag));
    }

    public void FlagUpdate(string flagName, bool setting)
    {
        if (flagName == movingFlag && setting != moving)
        {
            moving = setting;
        }
        else if (flagName == activeFlag && setting != active)
        {
            setActiveFlag(setting);
        }
    }

    private void setActiveFlag(bool setting)
    {
        renderer.color = setting ? activeColor : inactiveColor;
        renderer.sortingOrder = -1;
        collider.enabled = setting;
        active = setting;
    }
}
