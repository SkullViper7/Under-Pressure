using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletMenu bulletMenu = collision.GetComponent<BulletMenu>();
        if (bulletMenu)
        {
            Application.Quit();
        }
    }
}
