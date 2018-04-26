using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

    private List<Shooter> shooters;
    private bool shooting;

	void Awake () {
        shooters = new List<Shooter>(GetComponents<Shooter>());
        shooting = false;
    }

    void Start ()
    {
        foreach (Shooter shooter in shooters)
        {
            shooter.Shooting = false;
        }
    }

    private void Update()
    {
        bool isFireHeld = Input.GetKey(KeyCode.Z);

        if (shooting != isFireHeld)
        {
            shooting = isFireHeld;
            foreach (Shooter shooter in shooters)
            {
                shooter.Shooting = shooting;
            }
        }
    }
}
