using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfishSpawner : MonoBehaviour
{
    public GameObject StarfishPrefab;
    [SerializeField] private float RespawnTime;
    private Vector2 ScreenBounds;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    void Start()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(ObstacleWave());
    }

    private void SpawnObstacle()
    {
        float Y = Random.Range(minY, maxY);
        float X = Random.Range(minX, maxX);
        Instantiate(StarfishPrefab, transform.position + new Vector3(X, Y, 0), transform.rotation);
    }

    IEnumerator ObstacleWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(RespawnTime);
            SpawnObstacle();
        }
    }

}
