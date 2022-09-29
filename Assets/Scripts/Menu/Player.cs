using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite; 
    private Animator anim;
    [SerializeField]
    private float dirX = 0f;
    [SerializeField] private float movespeed;
    public bool facingRight = true;
    public static Player player;

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

        if (dirX != 0)
        {
            state = Movementstate.walk;
        }


        else
        {
            state = Movementstate.idle;
        }

        anim.SetInteger("state", (int)state);
        Debug.Log(state);
    }
    
}
