using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void takeDamage(int amount)
    {
        health -= amount;
        if(health < 0)
        {
            destroyPlayer();
        }
    }

    void destroyPlayer()
    {
        Debug.Log("Player Dead");
        Destroy(this);
    }
}
