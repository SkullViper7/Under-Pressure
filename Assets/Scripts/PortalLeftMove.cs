using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLeftMove : MonoBehaviour
{
    //Movement left
    public float moveSpeed = 5;

    void Start()
    {

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {

        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.fixedDeltaTime;

        if (pos.x < -4)
        {
            Destroy(gameObject);
        }
        transform.position = pos;
    }
}   
