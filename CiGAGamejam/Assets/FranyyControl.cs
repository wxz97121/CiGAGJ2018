using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FranyyControl : MonoBehaviour
{
    //Franxx
    public float RotateSpeed = 120;
    public float TenRotateSpeed = 100;
    public float DeadRot = 5;
    public float ForceByAngular = 1;
    private List<int> InputList;
    private GameObject TenPivot;
    private void Awake()
    {
        InputList = new List<int>();
        TenPivot = transform.Find("TenPivot").gameObject;
    }
    int GetDir(float x, float y)
    {
        if (x > 0.8) return 0;
        if (y > 0.8) return 1;
        if (x < -0.8) return 2;
        if (y < -0.8) return 3;
        return -1;
    }
    void UpdateDir()
    {
        int Dir = 0;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float tarZ = Mathf.Rad2Deg * Mathf.Atan2(-x, -y);
        //print(tarZ);
        float nowZ = transform.localRotation.eulerAngles.y;
        float Shun = (nowZ - tarZ + 720) % 360;
        float Ni = (tarZ - nowZ + 720) % 360;
        if (Shun < Ni) Dir = -1; else Dir = 1;
        if (Mathf.Abs(Mathf.Min(Shun, Ni) - 180) < DeadRot || 1 - x * x - y * y > 0.1) return;
        GetComponent<Rigidbody2D>().AddTorque(Dir * RotateSpeed);
    }
    int Lastdir = -1;
    void UpdateTen()
    {
        float x = Input.GetAxis("RHorizontal");
        float y = Input.GetAxis("RVertical");
        int Rdir = GetDir(x, y);
        /*弱智判圈
        if (Rdir != -1)
        {
            //print(InputList.Count);
            if (InputList.Count == 0) InputList.Add(Rdir);
            else if (InputList[InputList.Count - 1] != Rdir) InputList.Add(Rdir);
            if (InputList.Count == 3)
            {
                if (Mathf.Abs(InputList[1] - InputList[0]) == 2 ||
                    (((InputList[1] - InputList[0] + 4) % 4) != ((InputList[2] - InputList[1] + 4) % 4)))
                {
                    InputList.Clear();
                    InputList.Add(Rdir);
                }
            }
            if (InputList.Count == 4)
            {
                if (((InputList[1] - InputList[0] + 4) % 4) != ((InputList[2] - InputList[1] + 4) % 4) ||
                    ((InputList[2] - InputList[1] + 4) % 4) != ((InputList[3] - InputList[2] + 4) % 4) ||
                    Mathf.Abs(InputList[1] - InputList[0]) == 2)
                {
                    InputList.Clear();
                    InputList.Add(Rdir);
                }
                else
                {
                    int FinDir = ((InputList[1] - InputList[0] + 4) % 4);
                    //print(FinDir);
                    FinDir = FinDir == 1 ? 1 : -1;
                    TenPivot.GetComponent<Rigidbody>().AddRelativeTorque(0, 0, TenRotateSpeed * FinDir);
                    InputList.Clear();
                }
            }
        }*/


        //TODO：长时间无输入，Lastdir得变回 -1 ；
        if (Rdir != -1)
        {
            if (Lastdir != -1)
            {
                int FinDir = (Rdir - Lastdir + 4) % 4;
                if (FinDir == 2) FinDir = 0;
                else if (FinDir == 3) FinDir = -1;
                TenPivot.GetComponent<Rigidbody>().AddRelativeTorque(0, 0, TenRotateSpeed * FinDir);
            }
            Lastdir = Rdir;
        }
        TenPivot.transform.localEulerAngles = new Vector3(0, 0, TenPivot.transform.localEulerAngles.z);

    }
    float LastTenPivotZ = 0;
    private void FixedUpdate()
    {
        UpdateDir();
        UpdateTen();
        UpdateVelocity();
    }
    void UpdateVelocity()
    {
        //if (TenPivot.getc)
        float ZZAngularSpeed = (TenPivot.transform.localEulerAngles.z - LastTenPivotZ) / Time.fixedDeltaTime;
        LastTenPivotZ = TenPivot.transform.localEulerAngles.z;
        //print(ZZAngularSpeed);
        if (Mathf.Abs(ZZAngularSpeed) > 10000) return;
        GetComponent<Rigidbody2D>().AddForce(transform.forward * ForceByAngular * ZZAngularSpeed);
       
    }
    void Update()
    {

        //UpdateVelocity();
    }
}
