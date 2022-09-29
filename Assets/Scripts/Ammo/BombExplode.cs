using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    public Animator animator;

    void Start()
    {

    }

    void Update()
    {
        animator.Play("ExplosionAnim");
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
