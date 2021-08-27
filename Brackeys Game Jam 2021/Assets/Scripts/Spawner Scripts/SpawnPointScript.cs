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

    public GameObject objectToSpawn;
    public Transform walkToPoint;

    public bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {

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

    /*
    void spawnObject()
    {
        //amountSpawned++;
        if (isSpawning == false)
        {
            StartCoroutine(instantiateObject());
        }
    }

    IEnumerator instantiateObject()
    {
        isSpawning = true;

        GameObject go = Instantiate(objectToSpawn, this.transform.position, Quaternion.identity) as GameObject;
        go.GetComponent<EnemyBehavior>().spawnWalkPoint = walkToPoint.position;

        yield return new WaitForSeconds(spawnInterval);

        isSpawning = false;

    }

    */

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
            GameObject go = Instantiate(objectToSpawn, this.transform.position, Quaternion.identity) as GameObject;
            go.GetComponent<EnemyBehavior>().spawnWalkPoint = walkToPoint.position;

            yield return new WaitForSeconds(spawnInterval);
        }

        isSpawning = false;

    }

}
