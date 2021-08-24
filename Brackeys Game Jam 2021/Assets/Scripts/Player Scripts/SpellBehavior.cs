using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehavior : MonoBehaviour
{

    public bool hasBurn;
    public bool hasWet;
    public bool hasPoison;
    public bool hasFreeze;

    public bool timeSlow;
    public float slowdownTimer;

    public bool Transforms;
    public List<GameObject> transformList;

    public bool hasAreaOfEffect;
    public float areaOfEffectRadius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
