using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject food;
    private Vector3 foodSpawnPoint;
    public int timeInterval;
    public float foodChance;

    void Start()
    {
        StartCoroutine(foodTimer(timeInterval));
        foodSpawnPoint = this.transform.position;
    }
    

    public void SpawnFood()
    {
        Instantiate(food, foodSpawnPoint, Quaternion.identity);
    }
    private IEnumerator foodTimer(int time)
    {
        while (time > 0)
        {
            //Debug.Log(time--);
            time--;
            yield return new WaitForSeconds(1);
        }
        if ((int)Random.Range(0,100) < foodChance) SpawnFood();
        StartCoroutine(foodTimer(timeInterval));
    }
}
