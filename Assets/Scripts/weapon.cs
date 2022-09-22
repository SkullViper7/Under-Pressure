using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject BulletPrefab;

    void Update()
    {
        transform.rotation = Quaternion.identity;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(); 
        }
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
