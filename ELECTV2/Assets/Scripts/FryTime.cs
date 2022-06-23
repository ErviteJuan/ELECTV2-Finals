using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryTime : MonoBehaviour
{
    [HideInInspector] public Collider2D FoodCollider;
    public float Timer;
    public float FryPhase;
    public float FryLimit;
    public bool IsFrying;

    private void Start()
    {
        Timer = 0;
        FoodCollider = gameObject.GetComponent<Collider2D>();
        SwipeControl.SwipeAction += SwipeServe;
    }

    private void Update()
    {
        if (IsFrying)
        {
            FryTimer();
        }
    }
    
    //Sets out a timer
    void FryTimer()
    {
        Timer += 1 * Time.deltaTime;
        Timer = Mathf.Clamp(Timer, 0, FryLimit);
    }

    public void SwipeServe(SwipeDirection _dir)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (FoodCollider.OverlapPoint(mousePosition))
        {
            //Checks if the food has reached a cooked state
            if (_dir == SwipeDirection.Up && Timer >= FryPhase)
            {
                Debug.Log("Sent to table!");
                //Thinking on editing this later so when the object gets served, it automatically disappears but sends out a text
                gameObject.transform.position = new Vector2(0, 4.3f);
            }
        }
    }
}
