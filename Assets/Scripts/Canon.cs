using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{

    public Transform FirePoint;
    [SerializeField] private GameObject BombPrefab;

    [SerializeField] private float FireRate;
    private float t;

    private void Start()
    {
        t = FireRate;
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;

        if ((Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")) && t >= FireRate)
        {
            t = 0;
            Shoot();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke("Shoot");
        }

        t += Time.deltaTime;
    }

    private void Shoot()
    {
        Instantiate(BombPrefab, FirePoint.position, FirePoint.rotation);
    }
}
