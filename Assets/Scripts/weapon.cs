using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject BulletPrefab;

    [SerializeField] private float FireRate;

    private void Update()
    {
        transform.rotation = Quaternion.identity;

        if (Input.GetButtonDown("Fire1"))
        {
            InvokeRepeating("Shoot", .001f, FireRate);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke("Shoot");
        }
    }

    private void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
