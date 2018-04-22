using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableHero : MonoBehaviour {

    public Vector3 spawnPoint;

    [SerializeField]
    private float sleepTime;

    private Rigidbody2D rbody;
    private float sleepRemaining;
    private bool alive;

    public bool Alive {
        get { return alive; }
    }

    private void Awake ()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (sleepRemaining > 0)
        {
            sleepRemaining -= Time.deltaTime;

            if (sleepRemaining <= 0)
            {
                alive = true;
                gameObject.SetActive(true);
                rbody.MovePosition(spawnPoint);
            }
        }
    }

    public void Kill()
    {
        sleepRemaining = sleepTime;
        alive = false;
        gameObject.SetActive(false);
    }
}
