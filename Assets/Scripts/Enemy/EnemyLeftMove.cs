using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeftMove : MonoBehaviour
{
    //Movement left
    public float moveSpeed = 5;
    [SerializeField] private bool Freeze = false;
    public Animator animator;
    public GameObject BulletPrefab;

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

        if (Freeze == true && transform.position.x < 1.15)
        {
            moveSpeed = 0;
            animator.Play("PufferFishAnim");
        }

        if (pos.x < -2)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }

    public void Explode()
    {
        Transform transforme = transform;
        Instantiate(BulletPrefab, transform.position, transforme.rotation);
        Destroy(gameObject);
    }
}
