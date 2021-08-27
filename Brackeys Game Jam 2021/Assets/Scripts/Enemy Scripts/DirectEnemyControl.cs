using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectEnemyControl : MonoBehaviour
{
    private const string X_LABEL = "X";
    private const string Y_LABEL = "Y";
    
    private const string ATTACK_LABEL = "Attack";
    private const string VICTORY_LABEL = "Victory";
    private const string DEATH_LABEL = "Death";

    public bool causeAttack = false;
    public bool causeVictory = false;
    public bool causeDeath = false;

    public Animator controller;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (causeAttack) {
            controller.SetTrigger(ATTACK_LABEL);
            causeAttack = false;
        }
        if (causeVictory) {
            controller.SetTrigger(VICTORY_LABEL);
            causeVictory = false;
        }
        if (causeDeath) {
            controller.SetTrigger(DEATH_LABEL);
            causeDeath = false;
        }
    }
}
