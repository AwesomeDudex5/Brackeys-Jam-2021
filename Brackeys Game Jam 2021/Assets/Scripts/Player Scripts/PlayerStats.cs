using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.current.onFoodPickedUp += healPlayer;
        GameManager.current.SetHeatlhUI(health);
    }

    public void takeDamage(int amount)
    {
        health -= amount;
        GameManager.current.PlayerDamaged();
        if(health < 0)
        {
            destroyPlayer();
        }
    }

    void destroyPlayer()
    {
        Debug.Log("Player Dead lol");
        Destroy(this.gameObject);
    }

    void healPlayer(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
            health = maxHealth;
    }
}
