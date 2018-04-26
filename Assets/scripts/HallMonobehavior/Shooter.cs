using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour {
    [SerializeField]
    private int rapidFireCount;

    [SerializeField]
    private float repRest;

    [SerializeField]
    private float setRest;

    [SerializeField]
    private GameObject bulletPrefab;

    public bool Shooting;

    private int repCount;
    private float restToRep;
    private float restToSet;

    protected abstract List<Vector2> GetDirections();

    private void Awake()
    {
        repCount = 0;
        restToSet = 0;
        restToRep = 0;
        Shooting = true;
    }

    private void Update()
    {
        if (restToSet > 0)
        {
            restToSet -= Time.deltaTime;
        }
        else if (restToRep > 0)
        {
            restToRep -= Time.deltaTime;
        }
        else if (Shooting)
        {
            List<Vector2> directions = GetDirections();

            foreach (Vector2 dir in directions)
            {
                GameObject bullet = SpawnBullet();
                bullet.GetComponent<Bullet>()
                    .Setup(transform.position, dir);
            }

            repCount++;
            if (repCount == rapidFireCount)
            {
                repCount = 0;
                restToSet += setRest;
            }
            else
            {
                restToRep += repRest;
            }
        }
    }

    private GameObject SpawnBullet ()
    {
        return Instantiate(bulletPrefab);
    }
}
