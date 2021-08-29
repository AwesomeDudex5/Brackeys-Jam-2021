using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    //for testing, will use force spawn a certain amount per spawnpoint, 
    //which will be controlled by the Wave Manager
    public float spawnInterval;
    //public float spawnCap;
    public float amountSpawned;

    public GameObject[] objectToSpawn;
    private int spawnIndex;
    public Transform walkToPoint;

    public bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.current.onPlayerDied += stopSpawning;
    }

    // Update is called once per frame
    void Update()
    {

        /*if(isSpawning == false)
        {
            spawnObject();
        }
        */

    }

    public void spawnAmount(int amount)
    {
        // Debug.Log(gameObject.name + " amount to spawn: " + amount);
        StartCoroutine(instantiateObject(amount));
    }

    IEnumerator instantiateObject(int amount)
    {
        isSpawning = true;

        for (int i = 0; i < amount; i++)
        {
            spawnIndex = Random.Range(0, objectToSpawn.Length);
            GameObject go = Instantiate(objectToSpawn[spawnIndex], this.transform.position, Quaternion.identity) as GameObject;
            //go.GetComponent<EnemyBehavior>().spawnWalkPoint = walkToPoint.position;

            yield return new WaitForSeconds(spawnInterval);
        }

        isSpawning = false;

    }

    void stopSpawning()
    {
        StopAllCoroutines();
        GameManager.current.onPlayerDied -= stopSpawning;
    }

}
