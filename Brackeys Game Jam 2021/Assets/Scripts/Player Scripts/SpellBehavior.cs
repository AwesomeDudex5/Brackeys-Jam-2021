using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehavior : MonoBehaviour
{
    private Coroutine moveToTarget;
    public Vector3 target;
    public float speed;

    public bool hasBurn;
    public bool hasWet;
    public bool hasPoison;
    public bool hasGust;
    public bool hasBlackhole;
    public bool hasFreeze;
    public bool hasStaggered;
    public bool Transforms;

    public int damage;

    public bool timeSlow;

    public bool hasAreaOfEffect;
    public float areaOfEffectRadius;

    // Start is called before the first frame update
    void Start()
    {
        if (timeSlow)
        {
           GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject n in Enemys)
            {
                //n.GetComponent<EnemyBehavior>().setStatus();
                Object.Destroy(gameObject);
            }
        }
        else moveToTarget = StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }

        if (hasAreaOfEffect == true) SpellEffect(transform.position, areaOfEffectRadius);
        else
        {
            SpellEffect(transform.position, GetComponent<SphereCollider>().radius);
        }
        Object.Destroy(gameObject);
    }

    void SpellEffect(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach(Collider n in hitColliders)
        {
            if(n.gameObject.TryGetComponent(out EnemyBehavior component))
            {
                GameObject Enemy = n.gameObject;
                Enemy.GetComponent<EnemyBehavior>().takeDamage(damage);
                if (hasBurn) Enemy.GetComponent<EnemyBehavior>().setStatus(EnemyStatus.burn);
                if (hasFreeze) Enemy.GetComponent<EnemyBehavior>().setStatus(EnemyStatus.frozen);
                if (hasPoison) Enemy.GetComponent<EnemyBehavior>().setStatus(EnemyStatus.poison);
                if (hasWet) Enemy.GetComponent<EnemyBehavior>().setStatus(EnemyStatus.wet);
                if (hasStaggered) Enemy.GetComponent<EnemyBehavior>().setStatus(EnemyStatus.staggered);
                if (transform) Enemy.GetComponent<EnemyBehavior>().setStatus(EnemyStatus.transformed);
                if (hasBlackhole) Enemy.GetComponent<EnemyBehavior>().setStatus(EnemyStatus.blackholed);
                if (hasGust) Enemy.GetComponent<EnemyBehavior>().setStatus(EnemyStatus.gusted);
            }
        }
    }
}
