using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "attack1Collider")
        {
            Debug.Log("attack 1");
        }
        else if(other.gameObject.name == "attack2Collider")
        {
            Debug.Log("attack 2");
        }
        else if(other.gameObject.name == "attack3Collider")
        {
            Debug.Log("attack 3");
        }
    }
}
