using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Collector : MonoBehaviour
{
   private RaycastHit hit;
   
   
   private void Update()
   {
      if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1.0f))
      {
         if (hit.collider.TryGetComponent(out Collectable collectable))
         {
            
            if(collectable.TryCollect(transform.parent,transform))
            {
               //var collectableCount = hit.collider.gameObject.transform.childCount;
               Debug.Log("collectable'a çarptık");
               
            
               //Destroy(hit.collider.gameObject);
               transform.parent.position += Vector3.up;
               transform.position += Vector3.down;
            }
         }
      }
   }

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.green;
      Gizmos.DrawRay(transform.position,Vector3.forward);
   }
}
