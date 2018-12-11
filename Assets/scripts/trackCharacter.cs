using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackCharacter : MonoBehaviour
{
    GameObject targetCharacter;

	// Use this for initialization
	void Start ()
    {
        targetCharacter = GameObject.Find("Zero");
	}

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetCharacter.transform.position.x, transform.position.y, transform.position.z);
	}
}
