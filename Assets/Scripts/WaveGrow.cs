using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGrow : MonoBehaviour
{
    [SerializeField] float growTime;
    [SerializeField] float timer;
    [SerializeField] float maxsSize;

    public bool isMaxSize = false;

    void Start()
    {
        if (isMaxSize == false)
        {
            StartCoroutine(Grow());
        }

    }
    private IEnumerator Grow()
    {
        Vector2 startScale = transform.localScale;
        Vector2 maxScale = new Vector2(maxsSize, maxsSize);

        do
        {
            transform.localScale = Vector2.Lerp(startScale, maxScale, timer / growTime);
            timer += Time.deltaTime;
            yield return null;
        }
        while (timer < growTime);

        isMaxSize = true;

    }
}
