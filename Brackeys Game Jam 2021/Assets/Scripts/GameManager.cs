using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    public void Awake()
    {
        if (current == null)
        {
            current = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region List of Actions

    public Action onEnemyKilled;
    public void EnemyKilled()
    {
        if (onEnemyKilled != null)
            onEnemyKilled();
    }

    public Action onEnemySpawned;
    public void EnemySpawned()
    {
        if (onEnemySpawned != null)
            onEnemySpawned();
    }

    /* public Action<EnemyStatus> onStatusInflicted;
     public void StatusInflicted(EnemyStatus status)
     {
         if (onStatusInflicted != null)
             onStatusInflicted(status);
     }
     */
    public Action<int> onFoodPickedUp;
    public void FoodPickedUp(int amount)
    {
        if (onFoodPickedUp != null)
            onFoodPickedUp(amount);
    }

    #endregion

}
