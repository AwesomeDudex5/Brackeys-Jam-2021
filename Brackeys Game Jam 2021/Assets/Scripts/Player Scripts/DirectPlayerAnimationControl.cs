using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Just for me to test the BlendTree really, 
 *  but can use the same strategy for the actual controller */
public class DirectPlayerAnimationControl : MonoBehaviour
{
    private const string X_LABEL = "X";
    private const string Y_LABEL = "Y";
    
    private const string SPELL_LABEL = "Spell1";
    private const string SPELL2_LABEL = "Spell2";
    private const string SPELL3_LABEL = "Spell3";
    private const string HIT_LABEL = "Hit";
    private const string DEATH_LABEL = "Death";
    
    public float x;
    public float y;

    public bool causeSpell = false;
    public bool causeSpell2 = false;
    public bool causeSpell3 = false;
    public bool causeHit = false;
    public bool causeDeath = false;

    private Animator controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.SetFloat(X_LABEL, x);
        controller.SetFloat(Y_LABEL, y);

        if (causeSpell) {
            controller.SetTrigger(SPELL_LABEL);
        }
        if (causeSpell2) {
            controller.SetTrigger(SPELL2_LABEL);
        }
        if (causeSpell3) {
            controller.SetTrigger(SPELL3_LABEL);
        }
        if (causeHit) {
            controller.SetTrigger(HIT_LABEL);
        }
        if (causeDeath) {
            controller.SetBool(DEATH_LABEL, true);
        }
    }
}
