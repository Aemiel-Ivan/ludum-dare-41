using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableHero : MonoBehaviour {

    public Vector3 spawnPoint;

    [SerializeField]
    private float sleepTime;

    private SpriteRenderer spriteRenderer;
    private float sleepRemaining;
    private bool alive;

    public bool Alive {
        get { return alive; }
    }

    private void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (sleepRemaining > 0)
        {
            sleepRemaining -= Time.deltaTime;

            if (sleepRemaining <= 0)
            {
                alive = true;
                spriteRenderer.enabled = true;
            }
        }
    }

    public void Kill()
    {
        sleepRemaining = sleepTime;
        alive = false;
        spriteRenderer.enabled = false;
        transform.SetParent(transform.root);
        transform.position = spawnPoint;
    }
}
