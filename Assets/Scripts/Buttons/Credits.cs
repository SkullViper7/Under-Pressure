using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletMenu bulletMenu = collision.GetComponent<BulletMenu>();
        if (bulletMenu)
        {
            SceneManager.LoadScene("Credits");
        }

    }
}
