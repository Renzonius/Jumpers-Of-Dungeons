using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivador : MonoBehaviour
{
    public JaulaMovimiento sptJaula;

    SpriteRenderer sennalP1;
    SpriteRenderer sennalP2;

    BoxCollider colRef;

    private void Start()
    {
        sptJaula = gameObject.transform.GetComponentInParent<JaulaMovimiento>();
        sennalP1 = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        sennalP2 = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
        colRef = GetComponent<BoxCollider>();
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
            if (col.gameObject.CompareTag("Player") && sptJaula.posibilitarDesactivar)
            {
                sennalP1.color = new Color(255f, 255f, 255f, 255f);
            }
            else if (col.gameObject.CompareTag("Player2") && sptJaula.posibilitarDesactivar)
            {
                sennalP2.color = new Color(255f, 255f, 255f, 255f);
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            sennalP1.color = new Color(255f, 255f, 255f, 0f);
        }
        else if (col.gameObject.CompareTag("Player2"))
        {
            sennalP2.color = new Color(255f, 255f, 255f, 0f);
        }
    }
}

