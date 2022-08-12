using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    // Start is called before the first frame update

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WallBox"))
        {
            Debug.Log(other.gameObject.tag);
            Destroy(gameObject);
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            transform.GetComponentInParent<PlayerMovement>().LoseHeight();
        }
    }
    

}
