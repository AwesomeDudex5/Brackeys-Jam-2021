using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Just for me to test the BlendTree really, 
 *  but can use the same strategy for the actual controller */
public class DirectPlayerAnimationControl : MonoBehaviour
{
    private const string X_LABEL = "X";
    private const string Y_LABEL = "Y";
    
    public float x;
    public float y;

    public Animator controller;

    // Start is called before the first frame update
    void Start()
    {
        //controller = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.SetFloat(X_LABEL, x);
        controller.SetFloat(Y_LABEL, y);
    }
}
