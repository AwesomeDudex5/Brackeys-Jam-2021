using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickup : MonoBehaviour
{
    public int healAmount;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.current.FoodPickedUp(healAmount);
            Destroy(this.gameObject);
        }
    }

}
