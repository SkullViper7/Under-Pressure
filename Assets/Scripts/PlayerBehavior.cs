using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public static PlayerBehavior playerBehavior { get; private set; }
    public UnitHealth _playerHealth = new UnitHealth(5, 5);

    void Awake()
    {
        
    }

    void Update()
    {
        if (_playerHealth.Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void PlayerTakeDmg(int dmg)
    {
        PlayerBehavior.playerBehavior._playerHealth.DmgUnit(dmg);
    }
    private void PlayerHeal(int healing)
    {
        PlayerBehavior.playerBehavior._playerHealth.HealUnit(healing);
    }
}
