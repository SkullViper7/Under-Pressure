using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAmmo : MonoBehaviour
{
    [SerializeField] float Speed;
    private Rigidbody2D rb;
    private Vector2 ScreenBounds;

    bool canBeDestroyed;

    [SerializeField] private GameObject ExplosionPrefab;
    public Transform bombPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * Speed;
    }

    void Update()
    {
        if (transform.position.x < 1.19)
            {
                canBeDestroyed = true;
            }
        else
        {
            canBeDestroyed= false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyLeftMove enemy = collision.GetComponent<EnemyLeftMove>();
        if (enemy != null && canBeDestroyed == true)
        {
            Explode();
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
        Instantiate(ExplosionPrefab, bombPoint.position, bombPoint.rotation);
    }
}
