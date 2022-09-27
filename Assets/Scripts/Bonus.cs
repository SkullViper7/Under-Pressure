using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{

    public bool activateShield;
    public bool addGuns;
    void Start()
    {
        
    }

    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Movement player = collision.GetComponent<Player_Movement>();
        if (player != null)
        {
            Destroy(gameObject);
        }
    }

}
