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
    public Material RedMat, BlueMat, DefaultMat;
    public Transform LastLeftSphere, LastRightSphere, LastLeftCy, LastRightCy, LastMidSphere;
    void Copy(Transform from, Transform to)
    {
        to.localPosition = from.localPosition;
        to.localRotation = from.localRotation;
        to.localScale = from.localScale;
    }
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
        MidSphere.GetComponent<MeshRenderer>().material = DefaultMat;
        LeftCy.position = (LeftSphere.position + MidSphere.position) / 2;
        RightCy.position = (RightSphere.position + MidSphere.position) / 2;
        LeftCy.localScale = new Vector3(0.1f, ((LeftSphere.position - MidSphere.position).magnitude - 1) / 2, 0.1f);
        RightCy.localScale = new Vector3(0.1f, ((RightSphere.position - MidSphere.position).magnitude - 1) / 2, 0.1f);
        float LeftEulerX = Mathf.Rad2Deg * Mathf.Atan2(LeftSphere.position.z - MidSphere.position.z, LeftSphere.position.y - MidSphere.position.y);
        float RightEulerX = Mathf.Rad2Deg * Mathf.Atan2(RightSphere.position.z - MidSphere.position.z, RightSphere.position.y - MidSphere.position.y);
        LeftCy.localRotation = Quaternion.Euler(LeftEulerX, 0, 0);
        RightCy.localRotation = Quaternion.Euler(RightEulerX, 0, 0);
    }

    // Update is called once per frame
    public void Reverse()
    {
        //print("Fuck");
        Copy(LastLeftSphere, LeftSphere);
        Copy(LastLeftCy, LeftCy);
        Copy(LastMidSphere, MidSphere);
        Copy(LastRightCy, RightCy);
        Copy(LastRightSphere, RightSphere);
    }
    void FixedUpdate()
    {
        
        Copy(LeftSphere, LastLeftSphere);
        Copy(LeftCy, LastLeftCy);
        Copy(MidSphere, LastMidSphere);
        Copy(RightCy, LastRightCy);
        Copy(RightSphere, LastRightSphere);

        int isLeft = 0, isRight = 0;
        if (Input.GetKey(KeyCode.A)) isLeft--;
        if (Input.GetKey(KeyCode.D)) isLeft++;
        if (Input.GetKey(KeyCode.LeftArrow)) isRight--;
        if (Input.GetKey(KeyCode.RightArrow)) isRight++;
        if (Input.GetKey(KeyCode.Q))
        {
            print("Update!");
            LeftSphere.RotateAround(MidSphere.position, new Vector3(1, 0, 0), RotateSpeed * Time.fixedDeltaTime);
            LeftCy.RotateAround(MidSphere.position, new Vector3(1, 0, 0), RotateSpeed * Time.fixedDeltaTime);
            RightSphere.RotateAround(MidSphere.position, new Vector3(1, 0, 0), -RotateSpeed * Time.fixedDeltaTime);
            RightCy.RotateAround(MidSphere.position, new Vector3(1, 0, 0), -RotateSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            LeftSphere.RotateAround(MidSphere.position, new Vector3(1, 0, 0), -RotateSpeed * Time.fixedDeltaTime);
            LeftCy.RotateAround(MidSphere.position, new Vector3(1, 0, 0), -RotateSpeed * Time.fixedDeltaTime);
            RightSphere.RotateAround(MidSphere.position, new Vector3(1, 0, 0), RotateSpeed * Time.fixedDeltaTime);
            RightCy.RotateAround(MidSphere.position, new Vector3(1, 0, 0), RotateSpeed * Time.fixedDeltaTime);
        }
        if (isLeft != 0 && isRight != 0)
        {
            print("Yes!");
            //旋转左面三个东西
            LeftSphere.RotateAround(MidSphere.position, new Vector3(1, 0, 0), isLeft * RotateSpeed * Time.fixedDeltaTime);
            LeftCy.RotateAround(MidSphere.position, new Vector3(1, 0, 0), isLeft * RotateSpeed * Time.fixedDeltaTime);
            //LeftAttach.RotateAround(MidSphere.position, new Vector3(1, 0, 0), isLeft * RotateSpeed * Time.deltaTime);
            //旋转右面三个东西
            RightSphere.RotateAround(MidSphere.position, new Vector3(1, 0, 0), isRight * RotateSpeed * Time.fixedDeltaTime);
            RightCy.RotateAround(MidSphere.position, new Vector3(1, 0, 0), isRight * RotateSpeed * Time.fixedDeltaTime);
            //RightAttach.RotateAround(MidSphere.position, new Vector3(1, 0, 0), isRight * RotateSpeed * Time.deltaTime);
        }
        else
        {
            if (isLeft != 0)
            {
                MidSphere.RotateAround(LeftSphere.position, new Vector3(1, 0, 0), isLeft * RotateSpeed * Time.fixedDeltaTime);
                LeftCy.RotateAround(LeftSphere.position, new Vector3(1, 0, 0), isLeft * RotateSpeed * Time.fixedDeltaTime);
                RightSphere.RotateAround(LeftSphere.position, new Vector3(1, 0, 0), isLeft * RotateSpeed * Time.fixedDeltaTime);
                RightCy.RotateAround(LeftSphere.position, new Vector3(1, 0, 0), isLeft * RotateSpeed * Time.fixedDeltaTime);
            }
            if (isRight != 0)
            {
                MidSphere.RotateAround(RightSphere.position, new Vector3(1, 0, 0), isRight * RotateSpeed * Time.fixedDeltaTime);
                LeftCy.RotateAround(RightSphere.position, new Vector3(1, 0, 0), isRight * RotateSpeed * Time.fixedDeltaTime);
                LeftSphere.RotateAround(RightSphere.position, new Vector3(1, 0, 0), isRight * RotateSpeed * Time.fixedDeltaTime);
                RightCy.RotateAround(RightSphere.position, new Vector3(1, 0, 0), isRight * RotateSpeed * Time.fixedDeltaTime);
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
