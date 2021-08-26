using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public NavMeshAgent agent;

    private Transform playerTransform;
    [HideInInspector] public Vector3 spawnWalkPoint;

    // public LayerMask groundLayer, playerLayer;

    public float health;

    //Chase Player Behavior
    [Header("Chase State")]
    public float movementSpeed;
    public bool isHunting;


    //Attack Behavior
    [Header("Attack State")]
    public float attackRange;
    public float attackTime;
    private bool isAttacking;
    private Transform attackTarget;

    //Affected by Status Behavior
    [Header("Status Effect State")]
    public EnemyStatus status;
    [SerializeField] private float burnDuration;
    [SerializeField] private float burnRange;
    [SerializeField] private float staggeredDuration;
    [SerializeField] private float frozenDuration;
    [SerializeField] private float poisonDuration;
    [SerializeField] private float wetDuration;
    public GameObject[] animalTransformations;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GameObject.FindObjectOfType<NavMeshAgent>();
        movementSpeed = agent.speed;
        StartCoroutine(walkToSpawnPoint(spawnWalkPoint));


    }

    // Update is called once per frame
    void Update()
    {
        if (isHunting == true)
        {
            if (checkInAttackRange(playerTransform) == false)
            {
                chasePlayer(playerTransform);
            }
            if (checkInAttackRange(playerTransform) == true)
            {
                if (isAttacking == false)
                {
                    StartCoroutine(attack(attackTarget));
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            attackTarget = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            attackTarget = null;
        }
    }

    IEnumerator walkToSpawnPoint(Vector3 walkPoint)
    {
        isHunting = false;

        agent.SetDestination(walkPoint);
        yield return new WaitForSeconds(3f);

        isHunting = true;
    }

    void chasePlayer(Transform _player)
    {
        this.transform.LookAt(_player);
        agent.SetDestination(_player.position);
    }

    bool checkInAttackRange(Transform _player)
    {
        if (Vector3.Distance(_player.position, this.transform.position) > attackRange)
            return false;
        else
            return true;
    }

    IEnumerator attack(Transform _target)
    {
        isHunting = false;
        isAttacking = true;

        yield return new WaitForSeconds(attackTime);
        //put attack animation code here
        if (attackTarget != null)
            _target.GetComponent<PlayerStats>().takeDamage(1);

        isHunting = true;
        isAttacking = false;
    }

    public void setStatus(EnemyStatus infliction)
    {
        isHunting = false;
        status = infliction;
        partStatus(status);
    }

    public void resetStatus()
    {
        isHunting = true;
        agent.speed = movementSpeed;
        status = EnemyStatus.none;
    }

    void partStatus(EnemyStatus infliction)
    {
        switch (infliction)
        {
            case EnemyStatus.burn: StartCoroutine(burning());
                break;
            case EnemyStatus.frozen: StartCoroutine(freezing());
                break;
            case EnemyStatus.poison: StartCoroutine(poisoning());
                break;
            case EnemyStatus.staggered: StartCoroutine(staggering());
                break;
            case EnemyStatus.transformed: //do stuff
                break;
            case EnemyStatus.wet: //do stuff
                break;
            default:
                Debug.Log("No Status Applied");
                break;
        }
    }

   IEnumerator burning()
    {
        int timer = 0;
        agent.speed *= 1.5f;
        while(timer < burnDuration)
        {
            health--;
            timer++;
            agent.SetDestination(new Vector3(Random.Range(-burnRange, burnRange), this.transform.position.y, Random.Range(-burnRange, burnRange)));
            yield return new WaitForSeconds(1f);
        }
        resetStatus();
    }

    IEnumerator freezing()
    {
        int timer = 0;
        agent.speed = 0;
        while(timer < frozenDuration)
        {
            timer++;
            yield return new WaitForSeconds(1f);
        }
        resetStatus();
    }

    IEnumerator poisoning()
    {
        int timer = 0;
        agent.speed *= 0.5f;
        while (timer < poisonDuration)
        {
            health--;
            timer++;
            chasePlayer(playerTransform);
            yield return new WaitForSeconds(1f);
        }
        resetStatus();
    }

    IEnumerator staggering()
    {
        int timer = 0;
        agent.speed = 0;
        while (timer < staggeredDuration)
        {
            timer++;
            //add code for enemy to be pushed back, prolly something with rigidbodies
            yield return new WaitForSeconds(1f);
        }
        resetStatus();
    }

    void animalTransform()
    {
        int randIndex = Random.Range(0, animalTransformations.Length);
        Instantiate(animalTransformations[randIndex], this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
