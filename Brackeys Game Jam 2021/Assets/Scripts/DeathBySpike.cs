using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBySpike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            GameManager.current.PlayerDied();
        }
    }

}
