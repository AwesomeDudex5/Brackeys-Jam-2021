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
      //  AudioManager.instance.playMusic("Battle Theme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region List of Actions

    public Action<waveType> onParseWaveType;
    public void ParseWaveType(waveType type)
    {
        if(onParseWaveType != null)
        {
            onParseWaveType(type);
        }
    }

    public Action<int, int> onWaveSpawned;
    public void WaveSpawned(int waveNum, int amountToKill)
    {
        if(onWaveSpawned != null)
        {
            onWaveSpawned(waveNum, amountToKill);
        }
    }

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

    public Action<int> onSetHealthUI;
    public void SetHeatlhUI(int amount)
    {
        if (onSetHealthUI != null)
            onSetHealthUI(amount);
    }

    public Action<int> onFoodPickedUp;
    public void FoodPickedUp(int amount)
    {
        if (onFoodPickedUp != null)
            onFoodPickedUp(amount);
    }

    public Action onPlayerDamaged;
    public void PlayerDamaged()
    {
        if(onPlayerDamaged != null)
        {
            onPlayerDamaged();
        }
    }

    public Action onPlayerDied;
    public void PlayerDied()
    {
        if(onPlayerDied != null)
        {
            onPlayerDied();
        }
    }

    public Action<int, int> onSpellActivated;
    public void SpellActivated(int spellID, int cooldownTime)
    {
        if(onSpellActivated != null)
        {
            onSpellActivated(spellID, cooldownTime);
        }
    }

    public Action onSlowTimeCast;
    public void SlowTimeCast()
    {
        if(onSlowTimeCast != null)
        {
            onSlowTimeCast();
        }
    }

    #endregion

}
