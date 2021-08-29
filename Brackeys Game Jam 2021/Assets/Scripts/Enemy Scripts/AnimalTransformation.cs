using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTransformation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(walkThenDestroy());
    }


    IEnumerator walkThenDestroy()
    {



        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
