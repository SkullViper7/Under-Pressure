using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    [SerializeField] private float RespawnTime;
    private Vector2 ScreenBounds;

    void Start()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(ObstacleWave());
    }

    private void SpawnObstacle()
    {
        GameObject a = Instantiate(ObstaclePrefab) as GameObject;
        a.transform.position = new Vector2(ScreenBounds.x * -0.5f, Random.Range(-ScreenBounds.y * -1f, ScreenBounds.y * 3.5f));
    }

    IEnumerator ObstacleWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(RespawnTime);
            SpawnObstacle();
        }
    }

    void Update()
    {
        
    }
}
