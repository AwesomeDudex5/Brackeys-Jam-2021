using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInPlace : MonoBehaviour
{
    public float xRotationSpeed = 0;
    public float yRotationSpeed = 90;
    public float zRotationSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 speedVector = new Vector3(xRotationSpeed, yRotationSpeed, zRotationSpeed);
        transform.Rotate(speedVector * Time.deltaTime, Space.Self);
    }
}
