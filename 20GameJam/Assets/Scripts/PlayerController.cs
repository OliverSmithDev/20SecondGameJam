using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15;
    private Vector3 moveDirection;
    public Rigidbody rigidbody;
    public Vector3 rotateleft;
    public Vector3 rotateright;

    private bool CanmoveRight;
    private bool CanmoveLeft;
    public AudioSource carHorn;

    public GameManager gamemanager;
    void Update()
    {

        if (gamemanager.PreGameTimer <= 0)
        {
            if (Input.GetKeyDown("space"))
            {
                carHorn.Play();
            }
            if (Input.GetKeyDown("a"))
            {
                CanmoveLeft = true;
            }
            if (Input.GetKeyDown("d"))
            {
                CanmoveRight = true;
                Debug.Log("test");
            }

            if (Input.GetKeyUp("d"))
            {
                CanmoveRight = false;
            }
            if (Input.GetKeyUp("a"))
            {
                CanmoveLeft = false;
            }
            moveDirection = new Vector3(0, 0, Input.GetAxisRaw("Vertical")).normalized;

            if (CanmoveRight)
            {
                transform.Rotate(0, 100 * Time.deltaTime, 0);
            }
        
            if (CanmoveLeft)
            {
                transform.Rotate(0, -100 * Time.deltaTime, 0);
            }
        }
        
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);

       
        
    }
    
}
