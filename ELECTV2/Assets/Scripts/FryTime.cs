using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryTime : MonoBehaviour
{
    [HideInInspector] public Collider2D FoodCollider;
    public GameObject TextSpawn;
    public float Timer;
    public float FryPhase;
    public float FryLimit;
    public bool IsFrying;
    [HideInInspector] public float xRange = 4;

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
                IsFrying = false;
                gameObject.transform.position = new Vector3(Random.Range(xRange,-xRange), 4.0f);
                StartCoroutine(WaitCoroutine());     
            }
        }
    }

    public void SpawnText()
    {
        Vector3 textPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Debug.Log(textPosition);
        Instantiate(TextSpawn, textPosition, Quaternion.identity, transform);
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SpawnText();
        yield return new WaitForSeconds(0.5f);
        //Unsubscribes to swipeControl to avoid errors
        SwipeControl.SwipeAction -= SwipeServe;
        Destroy(this.gameObject);
    }
}
