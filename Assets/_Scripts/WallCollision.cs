using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool isTriggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WallBox")&& !isTriggered)
        {
            Debug.Log(other.gameObject.tag);
            Destroy(gameObject);
            
            transform.parent.position -= Vector3.up;
            // transform.parent.GetComponent<Rigidbody>().useGravity = true;
            // StartCoroutine(GravitySetup());
            isTriggered = true;
        }
    }

    IEnumerator GravitySetup()
    {
        
        yield return new WaitForSeconds(0.5f);
        transform.parent.GetComponent<Rigidbody>().useGravity = false;

    }

}
