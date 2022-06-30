using System;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float torqueAmount = 3f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 10f;

    bool canMove = true;


    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
     
    }
     public void DisableControls()
     {
        canMove = false;
     }
    void RotatePlayer() 
    {
        if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            rb2d.AddTorque(torqueAmount);
        }
         else if(Input.GetKey(KeyCode.RightArrow)) 
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost() 
    {
        if(Input.GetKey(KeyCode.UpArrow)) 
        {
            surfaceEffector2D.speed = boostSpeed;
        }
         else 
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
}
