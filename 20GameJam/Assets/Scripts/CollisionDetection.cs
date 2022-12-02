using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public float COLTimer = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        COLTimer-= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (COLTimer >= 0)
        {
            if (collision.gameObject.tag == "obstacle")
            {
                Destroy(gameObject);
                Debug.Log("Collision");
            }     
        }
        
       
    }
}
