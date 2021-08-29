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
   // public List<Spell> spellList;
    public int SpellMagnitude;
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
        //spellList = new List<Spell>();

         spellList = new Spell[] { new Spell(spellPrefabs[0], 15),
                                     new Spell(spellPrefabs[1], 15),
                                     new Spell(spellPrefabs[2], 15),
                                     new Spell(spellPrefabs[3], 15),
                                     new Spell(spellPrefabs[4], 15)};
                                     
        //spellList.Add(new Spell(spellPrefabs[0], 15));
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1)) ActivateSpell(spellList[0]);
        if (Input.GetKeyUp(KeyCode.Alpha2)) ActivateSpell(spellList[1]);
        if (Input.GetKeyUp(KeyCode.Alpha3)) ActivateSpell(spellList[2]);
        if (Input.GetKeyUp(KeyCode.Alpha4)) ActivateSpell(spellList[3]);
        if (Input.GetKeyUp(KeyCode.Alpha5)) ActivateSpell(spellList[4]);
    }

    public void ActivateSpell(Spell targetSpell)
    {
        if(targetSpell.isCooled())
        {
            GameObject newPrefab = Instantiate(targetSpell.spellPrefab, gameObject.transform.position + new Vector3(0, .75f, 0), Quaternion.identity);
            newPrefab.GetComponent<SpellBehavior>().target = transform.position + new Vector3(0, .75f, 0) + (transform.rotation *  new Vector3(0, 0, SpellMagnitude));
            targetSpell.cooldownStart();
            GameManager.current.SpellActivated(System.Array.IndexOf(spellList, targetSpell), targetSpell.cooldownTime);
        }
        Debug.Log("SpellChecked");
    }
}
