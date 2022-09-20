using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Stacker : MonoBehaviour
{
    
    [SerializeField] private float collectAnimDuration;
    [SerializeField] private float fallingAnimDuration;
    [SerializeField] private Transform stackParent;
    [SerializeField] private AnimationCurve collectAnimType;
    [SerializeField] private Ease fallingAnimType;
    
    private int startCBCount;
    void Start()
    {
        startCBCount = stackParent.childCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectableBox") && other.transform.parent != stackParent)
        {
            var collectedBox = other.transform;
            
            collectedBox.SetParent(stackParent);

            var stackCount = stackParent.childCount - startCBCount;

            var collectableCurrentPos = Vector3.up * stackCount;
            
            collectedBox.DOLocalMove(collectableCurrentPos, collectAnimDuration).SetEase(collectAnimType);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            var stackCounter = 0;
            foreach (Transform collectable in stackParent)
            {
                var currStackPosition = Vector3.up * stackCounter++;
               
                
                collectable.DOLocalMove(currStackPosition, fallingAnimDuration).SetEase(fallingAnimType);
            }
        }
    }
}
