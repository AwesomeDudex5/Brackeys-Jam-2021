using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{

    public GameObject[] spellPrefabs;
    /*
       Slow Time = 0
       Fireball = 1
       Black Hole = 2
       Gust = 3
       Transformation = 4 
    */
    public int[] cooldownTimes;
    private bool[] isCooling = {false, false, false, false, false};
    public int SpellMagnitude;
    public void Start()
    {


    }
    public void cooldownStart(int n, int i)
    {
        isCooling[i] = true;
        StartCoroutine(cooldownTimer(n, i));
    }

    private IEnumerator cooldownTimer(int time, int index)
    {
        while (time > 0)
        {
            time--;
            yield return new WaitForSeconds(1);
        }
        isCooling[index] = false;
        Debug.Log("cooled " + isCooling[index]);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1)) ActivateSpell(spellPrefabs[0]);
        if (Input.GetKeyUp(KeyCode.Alpha2)) ActivateSpell(spellPrefabs[1]);
        if (Input.GetKeyUp(KeyCode.Alpha3)) ActivateSpell(spellPrefabs[2]);
        if (Input.GetKeyUp(KeyCode.Alpha4)) ActivateSpell(spellPrefabs[3]);
        if (Input.GetKeyUp(KeyCode.Alpha5)) ActivateSpell(spellPrefabs[4]);
    }

    public void ActivateSpell(GameObject targetSpell)
    {
        if (!isCooling[System.Array.IndexOf(spellPrefabs, targetSpell)])
        {
            GameObject newPrefab = Instantiate(targetSpell, gameObject.transform.position + new Vector3(0, .75f, 0), Quaternion.identity);
            newPrefab.GetComponent<SpellBehavior>().target = transform.position + new Vector3(0, .75f, 0) + (transform.rotation *  new Vector3(0, 0, SpellMagnitude));
            cooldownStart(cooldownTimes[System.Array.IndexOf(spellPrefabs, targetSpell)], System.Array.IndexOf(spellPrefabs, targetSpell));
            GameManager.current.SpellActivated(System.Array.IndexOf(spellPrefabs, targetSpell), cooldownTimes[System.Array.IndexOf(spellPrefabs, targetSpell)]);
        }
    }
}
