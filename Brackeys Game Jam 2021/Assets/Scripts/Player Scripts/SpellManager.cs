using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public GameObject spellPrefab;
    public int cooldownTime;
    public int currentCooldown;

    public Spell(GameObject _spellPrefab, int _cooldownTime)
    {
        spellPrefab = _spellPrefab;
        cooldownTime = _cooldownTime;
        currentCooldown = 0;
    }

    public bool isCooled()
    {
        if (currentCooldown <= 0) return true;
        else return false;
    }
    // Cooldown Code would go here
    public void cooldownStart()
    {
        currentCooldown = cooldownTime;
        StartCoroutine(cooldownTimer());
    }

    IEnumerator cooldownTimer()
    {
        while (currentCooldown > 0)
        {
            currentCooldown--;
            yield return new WaitForSeconds(1f);
        }
    }
}

public class SpellManager : MonoBehaviour
{

    public GameObject[] spellPrefabs;
    public Spell[] spellList;
    //test spell
    public void Start()
    {
        /* 
           Slow Time = 0
           Fireball = 1
           Black Hole = 2
           Gust = 3
           Transformation = 4 
        */

        spellList = new Spell[] { new Spell(spellPrefabs[0], 15),
                                    new Spell(spellPrefabs[1], 15),
                                    new Spell(spellPrefabs[2], 15),
                                    new Spell(spellPrefabs[3], 15),
                                    new Spell(spellPrefabs[4], 15)};
    }

    public void Update()
    {
     }

    public void ActivateSpell(Spell targetSpell, Vector3 targetLocation)
    {
        if(targetSpell.isCooled())
        {
            GameObject newPrefab = Instantiate(targetSpell.spellPrefab, gameObject.transform.position, Quaternion.identity);
            newPrefab.GetComponent<SpellBehavior>().target = targetLocation;
            targetSpell.cooldownStart();
            GameManager.current.SpellActivated(System.Array.IndexOf(spellList, targetSpell), targetSpell.cooldownTime);
        }
        Debug.Log("SpellChecked");
    }
}
