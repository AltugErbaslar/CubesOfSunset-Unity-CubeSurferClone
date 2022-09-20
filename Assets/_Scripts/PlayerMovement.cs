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
    
    private void Update()
    {
        
        Movement();
        

    }

    void Movement()
    {
       transform.Translate(joystick.Horizontal*horizontalSpeed*Time.deltaTime,0,forwardSpeed*Time.deltaTime);
    }

    
}
