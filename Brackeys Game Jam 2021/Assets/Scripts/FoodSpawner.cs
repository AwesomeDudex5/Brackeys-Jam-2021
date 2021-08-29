using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject food;
    public Vector3 foodSpawnPoint;
    public int timeInterval;
    public float foodChance;

    void Start()
    {
        StartCoroutine(foodTimer(timeInterval));
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
        if (Random.value > foodChance) SpawnFood();
        StartCoroutine(foodTimer(timeInterval));
    }
}
