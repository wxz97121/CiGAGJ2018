using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroy_time=10.0f;
	// Use this for initialization
	void Start ()
    {
        Invoke("AutoDes",destroy_time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void AutoDes()
    {
        Destroy(gameObject);
    }
}
