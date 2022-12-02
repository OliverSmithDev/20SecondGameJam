using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerCollision : MonoBehaviour
{

    public GameManager gamemanager;

    public float ComboTimer = 3;

    public bool comboActive;

    public GameObject Deer;

    private Vector3 newscale;
    public float speed;
    public CameraShake CameraShake;

    public AudioClip[] collisionSound;
    public AudioSource randomSound;
    public AudioSource crashSound;



    private void Start()
    {
        newscale = new Vector3(0, 0, 0);
     
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "deer")
        {
            randomSound.clip = collisionSound[Random.Range(0, collisionSound.Length)];
            randomSound.Play();
            Deer = collision.gameObject;
            Deer.transform.localScale = Vector3.Slerp(Deer.transform.localScale, newscale, speed * Time.deltaTime);
            Destroy(collision.gameObject);
            Debug.Log("CollisionDeer");
            DeerCollision();
            comboActive = true;
            Deer.tag = "Untagged";
        }

        if (collision.gameObject.tag == "obstacle")
        {
            crashSound.Play();
        }
    }
    void Update()
    {
        if (comboActive)
        {
            ComboTimer -= Time.deltaTime;
        }

        if (ComboTimer <= 0)
        {
            ComboTimer = 3;
            comboActive = false;
        }
        

       

      
    }
    void DeerCollision()
    {
        //Deer.transform.localScale -= new Vector3(0.4f, 0.4f, 0.4f);
        //OriginalPos = camTransform.localPosition;
        
        
        if (comboActive)
        {
            gamemanager.Score += 5;
        }
        else
        {
            gamemanager.Score++; 
        }
        
        
    }
}
