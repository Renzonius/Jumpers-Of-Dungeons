using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivador : MonoBehaviour
{
    public JaulaMovimiento sptJaula;

    private void Start()
    {
        sptJaula = gameObject.transform.GetComponentInParent<JaulaMovimiento>();
    }

    private void OnTriggerStay(Collider col)
    {
        bool playerDesactiva = col.gameObject.GetComponent<JaulaInteraccion>().usarDesactivador;
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player2"))
        {
            if (sptJaula.posibilitarDesactivar && playerDesactiva)
            {
                sptJaula.obstActivado = false;
            }
        }
    }
}

