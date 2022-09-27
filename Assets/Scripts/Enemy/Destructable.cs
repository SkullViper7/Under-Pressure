using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] private GameObject player;
    bool canBeDestroyed = false;
    [SerializeField] private float hp = 5;

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
            PlayerTakeDmg(1);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
    }
}
