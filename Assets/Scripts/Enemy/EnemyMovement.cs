using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float xSpeed;
    public float ySpeed;

    public bool canShoot;
    public float fireRate;
    public float health;

    void Awake()
    {
        rb = GetComponent <Rigidbody2D>();
    }

    

    void Start()
    {
        
    }

    void Update()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
