using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FranyyControl : MonoBehaviour
{
    public float RotateSpeed = 120;
    public float DeadRot = 5;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int Dir = 0;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //float tarZ = Mathf.Rad2Deg * Mathf.Atan2(x, -y);
        //float nowZ = transform.rotation.eulerAngles.z;
        //float Shun = (nowZ - tarZ + 720) % 360;
        //float Ni = (tarZ - nowZ + 720) % 360;
        //if (Shun < Ni) Dir = -1; else Dir = 1;
        //if (Mathf.Min(Shun, Ni) < DeadRot || 1 - x * x - y * y > 0.1) return;
        //GetComponent<Rigidbody>().AddRelativeTorque(0, 0, Dir * RotateSpeed);

        x = Input.GetAxis("RHorizontal");
        y = Input.GetAxis("RVertical");
        //print(x);
        print(Mathf.Rad2Deg * Mathf.Atan2(y, x));

    }

}
