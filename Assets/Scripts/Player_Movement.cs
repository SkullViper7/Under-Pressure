using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationforce;
    [SerializeField] private float rotationspeed;
    public float Playerhp;


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);

        if (horizontalInput != 0)
        {
            transform.Rotate(Vector3.forward * (rotationforce * Mathf.Sign(-horizontalInput)) * Time.deltaTime);
            float angle = transform.eulerAngles.z;
            if (angle > 180)
                angle = angle - 360f;
            transform.eulerAngles = new Vector3(0, 0, Mathf.Clamp(angle, -30f,30f));
        }
        else
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, rotationspeed * Time.deltaTime);
        }

        var dist = (this.transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(-0.05f, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1.05f, 0, dist)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, -0.05f, dist)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.05f, dist)).y;

        Vector3 playerSize = this.gameObject.GetComponent<Renderer>().bounds.size;

        this.transform.position = new Vector3(
        Mathf.Clamp(this.transform.position.x, leftBorder + playerSize.x / 2, rightBorder - playerSize.x / 2),
        Mathf.Clamp(this.transform.position.y, topBorder + playerSize.y / 2, bottomBorder - playerSize.y / 2),
        this.transform.position.z
        );

        //Vie du joueur
        if (Playerhp <= 0)
        {
            Destroy(gameObject);
        }

    }
}
