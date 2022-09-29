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
        BombAmmo bomb = collision.GetComponent<BombAmmo>();
        BombExplode explode = collision.GetComponent<BombExplode>();
        if (canBeDestroyed == true)
        {
            if (bullet != null)
            {
                hp = hp - 1;
                if (Explosion == true)
                {
                    animator.Play("PufferFishAnim");
                }
            }
            if (bomb != null)
            {
                hp = hp - 3;
                if (Explosion == true)
                {
                    animator.Play("PufferFishAnim");
                }
            }
            if (explode != null)
            {
                hp = hp - 2;
                if (Explosion == true)
                {
                    animator.Play("PufferFishAnim");
                }
            }
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

    }

}



