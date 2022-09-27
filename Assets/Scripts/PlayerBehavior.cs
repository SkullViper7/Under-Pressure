using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //public static PlayerBehavior playerBehavior { get; private set; }

    void Awake()
    {

    }

    void Update()
    {
        if (GameManager.gameManager._playerHealth.Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
    }
    private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.HealUnit(healing);
    }
}
