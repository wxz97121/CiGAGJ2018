using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAddForce : MonoBehaviour
{
    public float force_min = 20.0f;
    public float force_max = 2000.0f;
    public float cur_force = 20.0f;
    public KeyCode[] key;
    public Transform force;

    Rigidbody2D rigid;
	// Use this for initialization
	void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        AddForce();
    }

    void AddForce()
    {
        if (Input.GetKey(key[0]))
        {
            rigid.AddForceAtPosition(force.forward * cur_force, force.position);
            cur_force += 2.0f;
            cur_force = Mathf.Clamp(cur_force,force_min,force_max);
        }
        else if (Input.GetKey(key[1]))
        {
            rigid.AddForceAtPosition(-force.forward * cur_force, force.position);
            cur_force += 2.0f;
            cur_force = Mathf.Clamp(cur_force, force_min, force_max);
        }
        else
        {
            cur_force = 0.0f;
        }
    }
}
