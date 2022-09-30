using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAmmo : MonoBehaviour
{
    [SerializeField] float Speed;
    private Rigidbody2D rb;
    private Vector2 ScreenBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * Speed;
    }

    private void Update()
    {
        if (transform.position.x > 1.24)
        {
            Destroy(gameObject);
        }

    }

}
