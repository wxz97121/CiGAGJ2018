using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiaoMiaoMove : MonoBehaviour
{
    public string hit_tag;
    public string destroy_tag;

    public Transform target;
    Vector3 tarAngle;

    public GameObject model1;
    public GameObject model2;
    public Transform measure1;
    public Transform measure2;
	// Use this for initialization
	void Start ()
    {
        tarAngle = transform.eulerAngles;
        StartCoroutine(ChangeModel());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        CauculateAngle();
        UpdateAngle();
    }

    void CauculateAngle()
    {
        Vector3 ori = transform.eulerAngles;
        transform.up = transform.position-target.position;
        tarAngle = transform.eulerAngles;
        transform.eulerAngles = ori;
    }
    void UpdateAngle()
    {
        float tarz = Mathf.LerpAngle(transform.localEulerAngles.z,tarAngle.z,0.2f);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y,tarz);
    }
    void UpdateMove()
    {
        transform.Translate(-Vector3.up*(measure1.position-measure2.position).magnitude,Space.Self);
    }
    IEnumerator ChangeModel()
    {
        while (true)
        {
            model1.SetActive(true);
            model2.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            model1.SetActive(false);
            model2.SetActive(true);
            UpdateMove();
            yield return new WaitForSeconds(0.1f);
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == hit_tag)
        {
            HitPlayer();
        }
        else if (collision.collider.tag == destroy_tag)
        {
            SelfDestroy();
        }
    }

    void HitPlayer()
    {
        
    }
    void SelfDestroy()
    {
       
    }
}
