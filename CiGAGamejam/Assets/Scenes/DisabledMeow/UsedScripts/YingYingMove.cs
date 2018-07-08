using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YingYingMove : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;

    public float shoot_wait=5.0f;
    public float shoot_inter = 0.2f;
    public float shoot_times = 10;

    public float shoot_speed = 200.0f;
    Vector3 tarAngle;

    public Transform[] fire_point;
    public GameObject bullet_prefab;

    // Use this for initialization
    void Start()
    {
        tarAngle = transform.eulerAngles;
        StartCoroutine(ShootProcess());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        CauculateAngle();
        UpdateAngle();
        UpdateMove();
    }

    void CauculateAngle()
    {
        Vector3 ori = transform.eulerAngles;
        transform.right = transform.position - target.position;
        tarAngle = transform.eulerAngles;
        transform.eulerAngles = ori;
    }
    void UpdateAngle()
    {
        float tarz = Mathf.LerpAngle(transform.localEulerAngles.z, tarAngle.z, 0.2f);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, tarz);
    }
    void UpdateMove()
    {
        transform.RotateAround(target.position,Vector3.forward,speed);
    }
    void Shoot()
    {
        foreach(Transform pos in fire_point)
        {
            GameObject bullet = Instantiate(bullet_prefab,pos.position,pos.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = pos.forward*shoot_speed;
        }
    }
    IEnumerator ShootProcess()
    {
        while (true)
        {
            yield return new WaitForSeconds(shoot_wait);
            for(int i = 0; i < shoot_times; i++)
            {
                Shoot();
                yield return new WaitForSeconds(shoot_inter);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = -speed;
    }
}
