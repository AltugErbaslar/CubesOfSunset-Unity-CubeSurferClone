using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMov : MonoBehaviour
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

        SetupHeight();
    }

    
    void Update()
    {
        ForwardMovement();
    }

    public void FixedUpdate()
    {
        JoystickMovement();
    }

    private bool isTriggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectableBox") && !isTriggered)
        {
            Debug.Log("trigger ent");
            
            transform.position += Vector3.up;
            
            other.transform.SetParent(transform);
            other.transform.localPosition = Vector3.down*(transform.childCount-2);



            Invoke(nameof(TriggeredFalse), 0.1f);
            isTriggered = true;
        }
        else if(other.CompareTag("WallBox") && !isTriggered)
        {
            Debug.Log("walboks");   
            Invoke(nameof(SetupHeight), 0.1f);
            
            Invoke(nameof(TriggeredFalse), 0.1f);
            isTriggered = true;
        }
    }
    private void TriggeredFalse()
    {
        isTriggered = false;
    }

    private void SetupHeight()
    {
        var mainPosition = new Vector3(transform.position.x, 0.5f + transform.childCount - 2, transform.position.z);
        transform.position = mainPosition;
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
