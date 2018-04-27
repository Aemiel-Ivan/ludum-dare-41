using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootable : Shootable {
    [SerializeField]
    private int baseHealth;

    private int currentHealth;
    private DeathEmitter emitter;

    void Awake () {
        currentHealth = baseHealth;
        emitter = GetComponent<DeathEmitter>();
	}
    
    public override void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            if (emitter != null)
            {
                emitter.EmitDeath();
            }

            Despawn();
        }
    }

    void Despawn()
    {
        DestroyObject(gameObject);
    }
}
