using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite; 
    private Animator anim;
    private float dirX = 0f;
    [SerializeField] private float movespeed;
    private bool facingRight = true;

    private enum Movementstate { idle, walk }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);

        UpdateAnimationState();

    }
    private void UpdateAnimationState()
    {
        Movementstate state;

        if (dirX > 0f && facingRight)
        {
            state = Movementstate.walk;
            Flip();
        }

        else if (dirX < 0f && !facingRight)
        {
            state = Movementstate.walk;
            Flip();
        }

        else
        {
            state = Movementstate.idle;
        }

        anim.SetInteger("state", (int)state);

    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
