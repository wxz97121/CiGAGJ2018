using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog2Control : MonoBehaviour
{
    private Transform LeftSphere;
    private Transform RightSphere;
    private Transform LeftCy;
    private Transform RightCy;
    //private Transform LeftAttach;
    //private Transform RightAttach;
    private Transform MidSphere;
    public float RotateSpeed = 45;
    public Material RedMat, BlueMat;
    private void Awake()
    {
        LeftSphere = transform.Find("LeftSphere");
        RightSphere = transform.Find("RightSphere");
        LeftCy = transform.Find("LeftCy");
        RightCy = transform.Find("RightCy");
        //LeftAttach = transform.Find("LeftAttach");
        //RightAttach = transform.Find("RightAttach");
        MidSphere = transform.Find("MidSphere");
        LeftSphere.GetComponent<MeshRenderer>().material = RedMat;
        RightSphere.GetComponent<MeshRenderer>().material = BlueMat;
        LeftCy.position = (LeftSphere.position + MidSphere.position) / 2;
        RightCy.position = (RightSphere.position + MidSphere.position) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        int isLeft = 0, isRight = 0;
        if (Input.GetKey(KeyCode.A)) isLeft--;
        if (Input.GetKey(KeyCode.D)) isLeft++;
        if (Input.GetKey(KeyCode.LeftArrow)) isRight--;
        if (Input.GetKey(KeyCode.RightArrow)) isRight++;
        if (isLeft!=0 && isRight!=0)
        {
            print("Yes!");
            //旋转左面三个东西
            LeftSphere.RotateAround(MidSphere.position, new Vector3(1, 0, 0), isLeft * RotateSpeed * Time.deltaTime);
            LeftCy.RotateAround(MidSphere.position, new Vector3(1, 0, 0), isLeft * RotateSpeed * Time.deltaTime);
            //LeftAttach.RotateAround(MidSphere.position, new Vector3(1, 0, 0), isLeft * RotateSpeed * Time.deltaTime);
            //旋转右面三个东西
            RightSphere.RotateAround(MidSphere.position, new Vector3(1, 0, 0), isRight * RotateSpeed * Time.deltaTime);
            RightCy.RotateAround(MidSphere.position, new Vector3(1, 0, 0), isRight * RotateSpeed * Time.deltaTime);
            //RightAttach.RotateAround(MidSphere.position, new Vector3(1, 0, 0), isRight * RotateSpeed * Time.deltaTime);
        }
        else
        {
            if (isLeft!=0)
            {
                MidSphere.RotateAround(LeftSphere.position, new Vector3(1, 0, 0), isLeft * RotateSpeed * Time.deltaTime);
                LeftCy.RotateAround(LeftSphere.position, new Vector3(1, 0, 0), isLeft * RotateSpeed * Time.deltaTime);
                RightSphere.RotateAround(LeftSphere.position, new Vector3(1, 0, 0), isLeft * RotateSpeed * Time.deltaTime);
                RightCy.RotateAround(LeftSphere.position, new Vector3(1, 0, 0), isLeft * RotateSpeed * Time.deltaTime);
            }
            if (isRight!=0)
            {
                MidSphere.RotateAround(RightSphere.position, new Vector3(1, 0, 0), isRight * RotateSpeed * Time.deltaTime);
                LeftCy.RotateAround(RightSphere.position, new Vector3(1, 0, 0), isRight * RotateSpeed * Time.deltaTime);
                LeftSphere.RotateAround(RightSphere.position, new Vector3(1, 0, 0), isRight * RotateSpeed * Time.deltaTime);
                RightCy.RotateAround(RightSphere.position, new Vector3(1, 0, 0), isRight * RotateSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RightSphere.gameObject.name = "MidSphere";
            MidSphere.gameObject.name = "RightSphere";
            Awake();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            LeftSphere.gameObject.name = "MidSphere";
            MidSphere.gameObject.name = "LeftSphere";
            Awake();
        }
    }
}
