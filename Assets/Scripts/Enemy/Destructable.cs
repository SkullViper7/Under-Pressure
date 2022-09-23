using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    bool canBeDestroyed = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.x < 1.19)
        {
            canBeDestroyed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (canBeDestroyed == true && bullet != null)
        {
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }
    }
}
