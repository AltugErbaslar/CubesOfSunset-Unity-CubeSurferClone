using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private bool canCollect = true;
  
    

    public bool TryCollect(Transform player,Transform collector)
    {
        if (!canCollect)
        {
            return false;
        }

        transform.parent = player;
        transform.position = collector.position + Vector3.down;
        canCollect = false;
        return true;
    }
}
