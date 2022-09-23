using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject BulletPrefab;

    [SerializeField] private float FireRate;
    private float NextFire;

    void Update()
    {
        transform.rotation = Quaternion.identity;

        if (Input.GetButtonDown("Fire1") && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            InvokeRepeating("Shoot", .001f, FireRate);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke("Shoot");
        }

    }
    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
