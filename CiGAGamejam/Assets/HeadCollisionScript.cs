using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionScript : MonoBehaviour {

    FranyyControl m_FranyyControl;
    private void Awake()
    {
        m_FranyyControl = GetComponentInParent<FranyyControl>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Arrow"))
            m_FranyyControl.BeDamage(-1);
    }
}
