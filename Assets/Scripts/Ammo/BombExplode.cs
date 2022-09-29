using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    [SerializeField] private float ExplosionTime = 1;

    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    void Update()
    {
        
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(ExplosionTime);
        Destroy(gameObject);
    }
}
