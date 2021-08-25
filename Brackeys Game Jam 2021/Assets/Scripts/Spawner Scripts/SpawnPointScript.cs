using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    //for testing, will use force spawn a certain amount per spawnpoint, 
    //which will be controlled by the Wave Manager
    public float spawnInterval;
    public GameObject objectToSpawn;
    public Transform walkToPoint;
    private bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isSpawning == false)
        {
            StartCoroutine(spawnObject());
        }
    }

    IEnumerator spawnObject()
    {
        isSpawning = true;

        GameObject go = Instantiate(objectToSpawn, this.transform.position, Quaternion.identity) as GameObject;
        go.GetComponent<EnemyBehavior>().spawnWalkPoint = walkToPoint.position;

        yield return new WaitForSeconds(spawnInterval);

        isSpawning = false;

    }
}
