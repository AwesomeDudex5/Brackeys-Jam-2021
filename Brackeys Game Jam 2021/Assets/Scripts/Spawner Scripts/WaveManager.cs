using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum waveType { normalWave, rockWave, cowWave }

public class WaveManager : MonoBehaviour
{
    public int currentWave = 0;
    public waveType TypeOfWave;
    //   public int amountSpawned; //counts how many alive in arena
    public int amountKilled;

    public int totalToKillPerWave;
    //  public int spawnCap; //max to have spawned on field
    public int incrementAmountAfterWave;
    public GameObject[] spawnPoints;
    private bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        //  GameManager.current.onEnemySpawned += updateCurrentAmountSpawned;
        canSpawn = true;
        GameManager.current.onEnemyKilled += updateCurrentAmountKilled;
        GameManager.current.WaveSpawned(currentWave, totalToKillPerWave);
        AudioManager.instance.playMusic("Battle Theme");
        AudioManager.instance.playSound("Crowd Noise");
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


    void SpawnEnemies()
    {
        canSpawn = false;
        int amountToSpawn = totalToKillPerWave;
        int amountForSpawners = amountToSpawn / spawnPoints.Length;
        int remainder = amountToSpawn % spawnPoints.Length;
        Debug.Log("Amount to Spawn: " + amountToSpawn + " Amount for Spawners: " + amountForSpawners + " Remainder: " + remainder);


        for (int i = 0; i < spawnPoints.Length; i++)
        {
            /* if (amountSpawned + spawnCap < amountToSpawn)
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
             */
            //  amountToSpawn = totalToKillPerWave - amountSpawned;


            /*
            if (i < spawnPoints.Length - 1)
                spawnPoints[i].GetComponent<SpawnPointScript>().spawnAmount(amountForSpawners);
            else
                spawnPoints[i].GetComponent<SpawnPointScript>().spawnAmount(amountForSpawners + remainder);
                */

            if (remainder > 0)
            {
                spawnPoints[i].GetComponent<SpawnPointScript>().spawnAmount(amountForSpawners + 1);
                remainder -= 1;
            }
            else
            {
                spawnPoints[i].GetComponent<SpawnPointScript>().spawnAmount(amountForSpawners);
            }

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
            amountKilled = 0;
            totalToKillPerWave += incrementAmountAfterWave;

            GameManager.current.WaveSpawned(currentWave, totalToKillPerWave);

        }
    }

    void parseWave()
    {
        if(currentWave%5 == 0)
        {
            int rand = Random.Range(0, 1);
            {
                if(rand ==0)
                {
                    TypeOfWave = waveType.rockWave;
                }
                else
                {
                    TypeOfWave = waveType.cowWave;
                }
            }
        }
        else
        {
            TypeOfWave = waveType.normalWave;
        }
    }
}
