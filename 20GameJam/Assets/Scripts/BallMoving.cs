using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
   public Vector3 Rotation;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Rotation);

        if (Input.GetKeyDown("space"))
        {
            Breaking();
        }   
        
        
    }



    void Breaking()
    {
        Rotation = new Vector3(0, 0, 0);
    }
}
