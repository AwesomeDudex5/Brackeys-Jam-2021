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
    [SerializeField] private float staggeredDuration;
    [SerializeField] private float frozenDuration;
    [SerializeField] private float poisonDuration;
    [SerializeField] private float wetDuration;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GameObject.FindObjectOfType<NavMeshAgent>();
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

}
