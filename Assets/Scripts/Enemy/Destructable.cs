using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] private bool Explosion = false;
    bool canBeDestroyed = false;
    [SerializeField] private float hp = 5;
    public Animator animator;

    void Update()
    {
        if (transform.position.x < 1.19)
        {
            canBeDestroyed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Collision avec le projectil du joueur
        Bullet_test bullet = collision.GetComponent<Bullet_test>();
        if (canBeDestroyed == true && bullet != null)
        {
            hp = hp - 1;
            Destroy(bullet.gameObject);
        }
        if (hp <= 0)
        {
            if (Explosion == true)
            {
                animator.Play("PufferFishAnim");
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }

}



