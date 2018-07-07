using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScale : MonoBehaviour
{
    public Transform head;
    public Transform curtail;
    Vector3 head_tarPos;
	// Use this for initialization
	void Start ()
    {
        head_tarPos = head.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        head.position = Vector3.MoveTowards(head.position,head_tarPos,0.2f);
	}

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddCube();
        }
    }

    void AddCube()
    {
        head_tarPos = curtail.position;
    }
}
