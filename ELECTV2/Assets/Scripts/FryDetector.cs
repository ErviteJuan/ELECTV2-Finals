using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryDetector : MonoBehaviour
{
    FryTime FryTimer;
    Collider2D GrillCollider;

    private void Start()
    {
        FryTimer = gameObject.GetComponent<FryTime>();
        GrillCollider = GameObject.Find("Grill").GetComponent<Collider2D>();
    }

    //Checks if the food has touched the grill which makes it fry
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == GrillCollider)
        {
            Debug.Log(this.name + " Is Frying!");
            FryTimer.IsFrying = true;
        }    
    }
}
