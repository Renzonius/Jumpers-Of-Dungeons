using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaulaInteraccion : MonoBehaviour
{
    public string teclaInteraccion;

    public bool usarDesactivador;
    public bool cercaDesactivador;

    public JaulaMovimiento sptJaula;

    public Animator animator;
    //Quaternion rotacionDeAccion;
    //Quaternion rotacionActural;

    public void DesactivarTrampas()
    {
        bool interactuar = Input.GetKeyDown(teclaInteraccion);

        if (interactuar && sptJaula.posibilitarDesactivar)
        {
            usarDesactivador = true;
            animator.SetTrigger("accion");
        }
        else
        {
            usarDesactivador = false;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
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
            sptJaula = col.gameObject.GetComponent<Desactivador>().sptJaula;
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
