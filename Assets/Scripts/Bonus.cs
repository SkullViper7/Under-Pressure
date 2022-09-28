using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] float speed;
    public bool activateShield;
    public bool addPowerUpBomb;
    public bool addPowerUpWave;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 pos = transform.position;

        pos.x -= speed * Time.fixedDeltaTime;


        if (pos.x < -2)
        {
            Destroy(gameObject);
        }

        transform.position = pos;

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
