using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    public GameObject spellPrefab;
    public float cooldownTime;
    public float currentCooldown;

    public Spell(GameObject _spellPrefab, float _cooldownTime)
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

    }
}

public class SpellManager : MonoBehaviour
{

    public List<Spell> spellList = new List<Spell>();
    public GameObject testSpellprefab;

    //test spell
    public void Start()
    {
        spellList.Add(new Spell(testSpellprefab, 150.0f));
    }

    public void Update()
    {
        ActivateSpell(spellList[0], new Vector3(6, 5, 10));
    }

    public void ActivateSpell(Spell targetSpell, Vector3 targetLocation)
    {
        if(targetSpell.isCooled())
        {
            GameObject newPrefab = Instantiate(targetSpell.spellPrefab, gameObject.transform.position, Quaternion.identity);
            newPrefab.GetComponent<SpellBehavior>().target = targetLocation;
            targetSpell.currentCooldown = targetSpell.cooldownTime;
            targetSpell.cooldownStart();
        }
        Debug.Log("SpellChecked");
    }
}
