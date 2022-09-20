using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectableBox"))
        {
            var collectable = other.transform;
            Destroy(other.GetComponent<BoxCollider>());
            collectable.SetParent(null);
        }
    }
}
