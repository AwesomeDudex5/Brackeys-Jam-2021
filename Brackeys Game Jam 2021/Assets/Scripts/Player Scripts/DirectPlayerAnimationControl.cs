using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Just for me to test the BlendTree really, 
 *  but can use the same strategy for the actual controller */
public class DirectPlayerAnimationControl : MonoBehaviour
{
    [HideInInspector] public const string X_LABEL = "X";
    [HideInInspector] public const string Y_LABEL = "Y";

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

    public Animator controller;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // controller.SetFloat(X_LABEL, x);
        // controller.SetFloat(Y_LABEL, y);

        if (causeSpell)
        {
            controller.SetTrigger(SPELL_LABEL);
            causeSpell = false;
        }
        if (causeSpell2)
        {
            controller.SetTrigger(SPELL2_LABEL);
            causeSpell2 = false;
        }
        if (causeSpell3)
        {
            controller.SetTrigger(SPELL3_LABEL);
            causeSpell3 = false;
        }
        if (causeHit)
        {
            controller.SetTrigger(HIT_LABEL);
            causeHit = false;
        }
        if (causeDeath)
        {
            controller.SetTrigger(DEATH_LABEL);
            causeDeath = false;
        }
    }
}
