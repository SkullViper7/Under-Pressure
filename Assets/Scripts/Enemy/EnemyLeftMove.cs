using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeftMove : MonoBehaviour
{
    //Movement left
    public float moveSpeed = 5;
    [SerializeField] private bool Freeze = false;

    void Start()
    {

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        //Movement left
        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.fixedDeltaTime;

        if (Freeze == true && transform.position.x < 1.15)
        {
            moveSpeed = 0;
        }

        if (pos.x < -2)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }
}
