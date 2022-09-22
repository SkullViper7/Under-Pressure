using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public enum states
    {
        straight,
        wavy,
        loop
    }

    public states currentState;
    public float speed;

    [Header("Wavy Variables")]
    public float amplitude;
    public float period;
    public float shift;
    public float yChange;
    private float newX;
    private float newY;

    private Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        switch (currentState)
        {
            case states.straight:
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, -speed);

                break;
            case states.wavy:
                newY = transform.position.y - yChange;
                newX = amplitude * Mathf.Sin(period * newY) + shift;
                Vector2 tempPosition = new Vector2(newX, newY);
                transform.position = tempPosition;
                break;
            case states.loop:

                break;
            default:
                break;
        }

    }
}
