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
        currentCooldown = _cooldownTime;
    }
}

public class SpellManager : MonoBehaviour
{

    public List<Spell> spellList = new List<Spell>();

    public void ActivateSpell(Spell targetSpell, Vector3 targetLocation)
    {
        GameObject newPrefab = Instantiate(targetSpell.spellPrefab, gameObject.transform);
    }
}
