using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform FirePoint;
    [SerializeField] private GameObject BulletMenuPrefab;
    [SerializeField] private float rotationforce;
    [SerializeField] private float FireRate;
    public Player player;

    private float t;


    private void Start()
    {
        t = FireRate;

    }

    private void Update()
    {
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
        
        float verticalInput = Input.GetAxis("Vertical");


        if (verticalInput != 0)
        {
            transform.Rotate(Vector3.forward * (rotationforce * Mathf.Sign(-verticalInput)) * Time.deltaTime);
            float angle = transform.eulerAngles.z;
            if (angle > 180)
                angle = angle - 360f;

            transform.eulerAngles = new Vector3(0, 0, Mathf.Clamp(angle, -45f, 45f));
        }
    }

    private void Shoot()
    {
        Instantiate(BulletMenuPrefab, FirePoint.position, FirePoint.rotation);
    }
}
