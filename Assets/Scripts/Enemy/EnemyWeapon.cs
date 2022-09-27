using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    bool canShoot = false;

    [SerializeField] private float FireRate;
    private float t;

    private void Start()
    {
        t = FireRate;
    }

    private void Update()
    {
 
        if (transform.position.x < 1.19)
        {
            canShoot = true;
        }

        if (t >= FireRate && canShoot)
        {
            t = 0;
            Shoot();
        }
        

        t += Time.deltaTime;
    }

    private void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
