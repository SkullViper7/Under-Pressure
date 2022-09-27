using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Rigidbody2D rb;
    private Vector2 ScreenBounds;

    void Start()
    {
        Debug.Log("screenbounds" + ScreenBounds);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-Speed, 0);
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if(transform.position.x < ScreenBounds.x * -2)
        {
            Destroy(gameObject);
        }
    }


}
