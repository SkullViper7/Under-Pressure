using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Sub-Sora_Second_Scene");
        Time.timeScale = 1;
    }
}
