using System.Collections;
using UnityEngine;

public class WallColl : MonoBehaviour
{
    private bool isTriggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectableBox"))
        {
            Debug.Log(other.gameObject.tag);
            Destroy(other.gameObject);
            
            Invoke(nameof(TriggeredFalse), 0.5f);
            isTriggered = true;
        }
    }
    private void TriggeredFalse()
    {
        isTriggered = false;
    }
}
