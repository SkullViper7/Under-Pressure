using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCharger : MonoBehaviour
{

    public Transform FirePoint;
    [SerializeField] private GameObject WavePrefab;

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
        Instantiate(WavePrefab, FirePoint.position, FirePoint.rotation);
    }
}
