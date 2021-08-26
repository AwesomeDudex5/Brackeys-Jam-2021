using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehavior : MonoBehaviour
{
    public bool isProjectile;
    private Coroutine moveToTarget;
    public Vector3 target;
    public float speed;

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
        if(isProjectile) moveToTarget = StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        while ((Vector3)transform.position != target)
        {
            transform.position = Vector3.MoveTowards((Vector3)transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
