using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Test : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationforce;
    [SerializeField] private float rotationspeed = 7f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);

        if (horizontalInput > 0f)
        {
            transform.Rotate(Vector3.forward * rotationforce * Time.deltaTime);
        }

        if (horizontalInput < 0f)
        {
            transform.Rotate(Vector3.back * rotationforce * Time.deltaTime);
        }

        else
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, rotationspeed * Time.deltaTime);
        }


    }
}
