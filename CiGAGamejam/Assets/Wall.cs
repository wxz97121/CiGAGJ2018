using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    private Frog2Control m_Controller;
    private void Awake()
    {
        m_Controller = FindObjectOfType<Frog2Control>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_Controller.Reverse();
        }
    }
}
