using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout : MonoBehaviour
{
    public Stick storeStick;
    public Ingredient storeIngredient;
    public Collider2D ColliderSource;
    public GameObject Grill;
    public GameObject Table;
    public GameObject CreatedFood;
    [SerializeField] AddIngredient PileStick;
    [SerializeField] AddIngredient PileBanana;
    [SerializeField] AddIngredient PileKamote;

    private void Start()
    {
        SwipeControl.SwipeAction += SendToFry; 
    }

    public void AddStick(Stick _s)
    {
        if (storeStick == null)
        {
            Debug.Log("Added " + _s.IngredientName);
            storeStick = _s;
        }
    }

    public void AddFood(Ingredient _i)
    {
        if (storeIngredient == null)
        {
            Debug.Log("Added " + _i.IngredientName);
            CreatedFood = Instantiate(_i.IngrdientPiece, new Vector3(0.2f, -3.3f, 0f), Quaternion.identity);
            storeIngredient = _i;
        }
    }

    public void SendToFry(SwipeDirection _dir)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (ColliderSource.OverlapPoint(mousePosition))
        {
            if (storeStick != null && storeIngredient != null)
            {
                if (storeIngredient.ID == 1)
                {
                    Debug.Log("Sent Kamote");
                    CreatedFood.transform.position = Grill.transform.position;
                }
                else if (storeIngredient.ID == 2)
                {
                    Debug.Log("Sent Banana");
                    CreatedFood.transform.position = Grill.transform.position;
                }
                storeIngredient = null;
                storeStick = null;
                CreatedFood = null;
                
            }
            else
            {
                Debug.Log("Incomplete!");
            }
        } 
    }
}