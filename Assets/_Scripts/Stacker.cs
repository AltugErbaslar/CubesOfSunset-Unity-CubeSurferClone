using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using TMPro;





public class Stacker : MonoBehaviour
{
    
    [SerializeField] private float collectAnimDuration;
    [SerializeField] private float fallingAnimDuration;
    public Transform stackParent;
    [SerializeField] private AnimationCurve collectAnimType;
    [SerializeField] private Ease fallingAnimType;
    
    [SerializeField] private int moneyValue;
    [SerializeField] private ParticleSystem moneyExplosion;
    public int money;
    public TextMeshProUGUI moneyText;
    public bool isGameActive = false;
    [SerializeField] private CinemachineVirtualCamera endingCam;
    private GameManager gameManager;
    
    private int startCBCount;
    void Start()
    {
        startCBCount = stackParent.childCount;
        money = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

        if (other.CompareTag("Money"))
        {
            Destroy(other.gameObject);
            UpdateMoney(moneyValue);
            Instantiate(moneyExplosion, transform.position+ (Vector3.forward*2),transform.rotation);
            
        }

        if (other.CompareTag("Finish")&& stackParent.childCount >10)
        {
            endingCam.Priority = 20;
            money *= 10;
        }
        else if (other.CompareTag("Finish"))
        {
            endingCam.Priority = 20;
            money *= stackParent.childCount;
        }
        
        
        
        if (other.CompareTag("FinishRamp"))
        {
            gameManager.Succes();
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
    public void UpdateMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        moneyText.text = "" + money;
    }
    
    
    

    
}
