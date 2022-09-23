using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    bool canBeDestroyed = false;
    [SerializeField] private float hp;

    void Start()
    {
        
    }

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
        Bullet bullet = collision.GetComponent<Bullet>();
        if (canBeDestroyed == true && bullet != null)
        {
            hp = hp - 1;
            Destroy(bullet.gameObject);
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        //Collision entre l'ennemi et le joueur
        Player_Movement player = collision.GetComponent<Player_Movement>();
        if (player != null)
        {
            Playerhp = Playerhp - 1;
        }
    }
}
