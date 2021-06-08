using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaulaInteraccion : MonoBehaviour
{
    public string teclaInteraccion;

    public bool usarDesactivador;
    public bool cercaDesactivador;

    public void DesactivarTrampas()
    {
        if (Input.GetKey(teclaInteraccion))
        {
            usarDesactivador = true;
        }
        else
            usarDesactivador = false;
    }

    void FixedUpdate()
    {
        if (cercaDesactivador)
        {
            DesactivarTrampas();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Desactivador")
        {
            cercaDesactivador = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Desactivador")
        {
            cercaDesactivador = false;
        }
    }
}
