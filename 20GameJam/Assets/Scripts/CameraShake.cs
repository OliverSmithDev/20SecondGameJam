using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    

    public GameObject cameraPos;

    private Vector3 OriginalPos;

    private void Start()
    {
        
        StartCoroutine(Shake(0.15f, 0.00005f));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, 0.01551f);
            elapsed += Time.deltaTime;
            yield return 0;
        }

        transform.position = cameraPos.transform.position;
        StartCoroutine(Shake(0.15f, 0.00005f));
    }
}
    
    
    
 