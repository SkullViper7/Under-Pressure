using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Movement player = collision.GetComponent<Player_Movement>();
        if (player != null)
        {
            SceneManager.LoadScene("Viper");
        }
    }
}
