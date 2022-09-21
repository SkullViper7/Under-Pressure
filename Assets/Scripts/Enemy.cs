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
    private Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        switch(currentState)
        {
            case states.straight:
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, -speed);

                break;
            case states.wavy:

                break;
            case states.loop:

                break;
            default:
                break;
        }
    }
}
