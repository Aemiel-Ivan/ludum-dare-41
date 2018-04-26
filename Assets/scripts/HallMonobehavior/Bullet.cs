using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private string target;

    [SerializeField]
    private float speed;

    private Vector2 velocity;
    private Rigidbody2D rbody;

    void Awake ()
    {
        this.rbody = GetComponent<Rigidbody2D>();
	}

    public void Setup (Vector2 position, Vector2 direction)
    {
        this.transform.position = position;
        this.velocity = direction.normalized * speed;
    }
	
	void FixedUpdate ()
    {
        Vector2 displacement = velocity * Time.fixedDeltaTime;
        rbody.MovePosition(rbody.position + displacement);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hall Wall" || collision.tag == target)
        {
            Shootable[] shootables = collision.GetComponents<Shootable>();
            foreach (Shootable shootable in shootables)
            {
                shootable.TakeDamage();
            }

            Despawn();
        }
    }

    private void Despawn()
    {
        ObjectPool.Instance.ReleaseObject(gameObject);
    }
}
