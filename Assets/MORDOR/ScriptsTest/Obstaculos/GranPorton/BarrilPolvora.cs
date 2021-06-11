using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrilPolvora : MonoBehaviour
{
    SpriteRenderer sennalTecla;
    void Start()
    {
        sennalTecla = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player")|| col.gameObject.CompareTag("Player2"))
        {
            sennalTecla.color = new Color(255, 255, 255, 255);
        }
    }

    //private void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player2"))
    //    {
    //        sennalTecla.color = new Color(255, 255, 255, 255);
    //    }
    //}

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player2"))
        {
            sennalTecla.color = new Color(255, 255, 255, 0);
        }
    }
}
