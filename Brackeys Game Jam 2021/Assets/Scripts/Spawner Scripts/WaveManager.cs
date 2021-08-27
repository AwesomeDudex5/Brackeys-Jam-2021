using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave = 0;
    public int amountSpawned; //counts how many alive in arena
    public int amountKilled;

    public int totalToKillPerWave;
    public int spawnCap; //max to have spawned on field
    public int incrementAmountAfterWave;
    public GameObject[] spawnPoints;
    private bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        //  GameManager.current.onEnemySpawned += updateCurrentAmountSpawned;
        canSpawn = true;
        GameManager.current.onEnemyKilled += updateCurrentAmountKilled;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkWaveFinished() == false)
        {
            if (canSpawn == true)
            {
                SpawnEnemies();
            }
        }
    }

    /* void initializeWave()
     {
         /* float randIndex;

          int amountToSpawn = totalPerWave - amountInSpawnSet;

          currentInWave++;
          for(int i=0; i < totalPerWave; i++)
          {
              randIndex = Random.Range(0, spawnPoints.Length-1);
             // if(spawnPoints[randIndex].GetComponent<SpawnPointScript>().)
          }


         currentWave++;
     }
 */

    /* void SpawnEnemies()
     {
         int randomIndex = 0;

         if (amountKilled < totalToKillPerWave)
         {
             if(amountSpawned < spawnCap)
             {
                 int amountToSpawn = spawnCap - amountSpawned;

                 for(int i = 0; i < amountToSpawn; i++)
                 {
                     //choose random spawnPoint
                     randomIndex = Random.Range(0, spawnPoints.Length - 1);
                     if(spawnPoints[randomIndex].GetComponent<SpawnPointScript>().isSpawning == false)
                     {
                         spawnPoints[randomIndex].GetComponent<SpawnPointScript>().spawnAmount(spawnAmountAtTime);
                         amountSpawned += spawnAmountAtTime;
                         amountToSpawn = spawnCap - amountSpawned;
                     }
                 }
             }
         }
     }
     */


    void SpawnEnemies()
    {
        canSpawn = false;
        int amountToSpawn = totalToKillPerWave - amountSpawned;
        Debug.Log("Amount to Spawn: " + amountToSpawn);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (amountSpawned + spawnCap < amountToSpawn)
            {
                int randAmountToSpawn = Random.Range(1, spawnCap);
                spawnPoints[i].GetComponent<SpawnPointScript>().spawnAmount(randAmountToSpawn);
                amountSpawned += randAmountToSpawn;
            }
            else
            {
                int setAmountToSpawn = amountToSpawn - amountSpawned;
                spawnPoints[i].GetComponent<SpawnPointScript>().spawnAmount(setAmountToSpawn);
                amountSpawned += setAmountToSpawn;
                break;
            }
            //  amountToSpawn = totalToKillPerWave - amountSpawned;
        }
        if (amountSpawned < totalToKillPerWave)
        {
            Debug.Log("cONT SPAWN");
            SpawnEnemies();
        }


    }

    bool checkWaveFinished()
    {
        if (amountKilled < totalToKillPerWave)
            return false;
        else if (amountKilled >= totalToKillPerWave)
            return true;
        else
            return false;
    }

    /* void updateCurrentAmountSpawned()
     {
         amountSpawned++;
     }
     */

    void updateCurrentAmountKilled()
    {
        amountKilled++;
        //  amountSpawned--;

        //kill condition reached, increment next wave
        if (checkWaveFinished() == true)
        {
            canSpawn = true;
            currentWave++;
            totalToKillPerWave += incrementAmountAfterWave;
        }

    }

}
