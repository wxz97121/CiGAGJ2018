using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            GetComponent<Rigidbody>().AddRelativeTorque(Vector3.up*100,ForceMode.Impulse);
        }
    }

}
