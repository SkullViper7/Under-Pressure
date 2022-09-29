using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletMenu bulletMenu = collision.GetComponent<BulletMenu>();
        if (bulletMenu)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
