using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public Animator transition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Movement player = collision.GetComponent<Player_Movement>();
        if (player != null)
        {
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("Level2");
    }
}
