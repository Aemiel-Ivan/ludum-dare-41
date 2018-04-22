using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour {
	
	private void OnCollisionEnter2D(Collision2D collision)
    {
        KillableHero hero = collision.gameObject.GetComponent<KillableHero>();
        if (hero != null)
        {
            hero.Kill();
        }
    }
}
