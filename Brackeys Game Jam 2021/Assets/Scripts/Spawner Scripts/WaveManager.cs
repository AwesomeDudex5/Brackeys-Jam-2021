using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave = 0;
    public int currentInWave = 0;

    public int totalPerWave;
    public int amountInSpawnSet;
    public int incrementAmountAfterWave;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initializeWave()
    {
        float randIndex;

        int amountToSpawn = totalPerWave - amountInSpawnSet;

        currentInWave++;
        for(int i=0; i < totalPerWave; i++)
        {
            randIndex = Random.Range(0, spawnPoints.Length-1);
           // if(spawnPoints[randIndex].GetComponent<SpawnPointScript>().)
        }
    }

}
