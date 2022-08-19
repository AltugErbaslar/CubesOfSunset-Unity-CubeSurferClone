using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Joystick joystick;
    private Rigidbody playerRb;
    [SerializeField] private float forwardSpeed = 20;
    [SerializeField] private float horizontalSpeed = 2;
    

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        Movement();
        

    }

    void Movement()
    {
        var velocity = playerRb.velocity;
        velocity.z = forwardSpeed;
        

        var horizontalInput = joystick.Horizontal;

        velocity.x = horizontalInput * horizontalSpeed;
        playerRb.velocity = velocity;
    }

    
}
