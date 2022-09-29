using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    private Scene scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    public void ReLoad()
    {
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }
}
