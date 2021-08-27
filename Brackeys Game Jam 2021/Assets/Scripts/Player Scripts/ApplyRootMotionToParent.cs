using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRootMotionToParent : MonoBehaviour
{

    private Animator controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Animator>();
    }

    void OnAnimatorMove()
    {
        this.transform.parent.position += controller.deltaPosition;
    }
}
