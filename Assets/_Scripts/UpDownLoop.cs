using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UpDownLoop : MonoBehaviour
{
    [SerializeField] private float endValue = 0.5f;
    [SerializeField] private Ease upDownAnimationType;
    [SerializeField] private float animationDuration;

    private void Start()
    {

        
        transform.DOMoveY(endValue, animationDuration).SetEase(upDownAnimationType).SetLoops(-1,LoopType.Yoyo);
    }
}
