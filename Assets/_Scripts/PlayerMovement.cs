using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float moveSpeed=20.0f;
    public float horizontalSpeed;

    [SerializeField] private Joystick joystick;
    [SerializeField] private float acceleration;
    private float height = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        ForwardMovement();
    }

    public void FixedUpdate()
    {
        JoystickMovement();
    }


   

    // Collision interaction with collectable box
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectableBox"))
        {
            
            var currentPosition = transform.position;
            height++;
            currentPosition.y = height;
            transform.position = currentPosition;
            
            
            other.transform.SetParent(transform);
            other.transform.localPosition = Vector3.down * (height-1);
        }
    }
    
    //Decreases the height after a certain time
    public void LoseHeight()
    {
        StartCoroutine(HeightLossDelayer());
        
        IEnumerator HeightLossDelayer()
        {
            yield return new WaitForSeconds(0.1f);
            var currentPosition = transform.position;
            currentPosition.y = --height;
            transform.position = currentPosition;
        }
        
    }

    //Constant forward movement
    void ForwardMovement()
    {
        var velocity = rb.velocity;
        velocity.z = moveSpeed;
        rb.velocity = velocity;
    }
    
    
    
    //Constant left and right movement 
    void JoystickMovement()
    {
        var horizontal = joystick.Horizontal;
        var currentSpeed = rb.velocity.x;
        var targetSpeed = horizontal * horizontalSpeed;
        var velocityChange = targetSpeed - currentSpeed;
        var direction = 0;
        if (velocityChange>0)
        {
            direction = 1;
        }
        else if (velocityChange < 0)
        {
            direction = -1;
        }

        Vector3 horizontalForce = Vector3.right * (acceleration * direction);
        
        rb.AddForce(horizontalForce,ForceMode.VelocityChange);
    }
}
