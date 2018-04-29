using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootablePlatformerHero : Shootable {
    private KillableHero killable;

    void Awake()
    {
        killable = GetComponent<KillableHero>();
    }

    public override void TakeDamage()
    {
        killable.Kill();
    }
}
