using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMenu : MonoBehaviour
{
    [SerializeField] float Speed;
    private Rigidbody2D rb;
    private Vector2 ScreenBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        Vector2 pos = transform.position;

        pos.x -= Speed * Time.fixedDeltaTime;

        if (pos.x < -2)
        {
            Destroy(gameObject);
        }

        transform.position = pos;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy_Movement enemy = collision.GetComponent<Enemy_Movement>();
        if (enemy != null)
        {
            Destroy(gameObject);
        }
    }

}
