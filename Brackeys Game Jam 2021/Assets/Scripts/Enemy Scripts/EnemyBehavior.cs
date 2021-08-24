using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask groundLayer, playerLayer;

    public float health;

    //Chase Player Behavior
    [Header("Chase State")]
    public float movementSpeed;
    private bool isHunting;


    //Attack Behavior
    [Header("Attack State")]
    public float attackRange;
    private bool isAttacking;

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
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
