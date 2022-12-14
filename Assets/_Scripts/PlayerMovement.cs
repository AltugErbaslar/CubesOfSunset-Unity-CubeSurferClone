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
    private float xRange = 2;
    private Stacker stackerScript;

    private void Start()
    {
        stackerScript = GameObject.Find("Stacker").GetComponent<Stacker>();
    }

    private void Update()
    {
        
        Movement();
        Border();
        

    }

    void Movement()
    {

        if (stackerScript.stackParent.childCount != 0 && stackerScript.isGameActive)
        {
            transform.Translate(joystick.Horizontal*horizontalSpeed*Time.deltaTime,0,forwardSpeed*Time.deltaTime);
        }
        
    }

    private void Border()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    
}
