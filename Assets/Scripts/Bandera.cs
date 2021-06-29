using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandera : MonoBehaviour
{
    public GameObject zonaDesactivar;
    public GameObject ZonaActivar;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player2"))
        {
            zonaDesactivar.SetActive(false);
            ZonaActivar.SetActive(true);
        }
    }
}
