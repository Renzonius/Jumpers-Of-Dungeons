using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenduloInteraccion : MonoBehaviour
{
    public bool jugadorCortado;

    public ParabolaController parabolaDeCaida;

    public MovimientoGeneral movimientoSpt;

    Animator animator;

    void CortePendulo()
    {
        parabolaDeCaida.FollowParabola();
        jugadorCortado = false;
    }

    void Start()
    {
        movimientoSpt = GetComponent<MovimientoGeneral>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (jugadorCortado)
        {
            CortePendulo();
            animator.SetBool("caida", true);
        }
    }


    private void OnTriggerEnter(Collider col)
    {
        string tipoTag = col.gameObject.tag;
        switch (tipoTag)
        {
            case "Parabola":
                parabolaDeCaida = GetComponent<ParabolaController>();
                parabolaDeCaida.ParabolaRoot = col.gameObject;
                parabolaDeCaida.generarRuta = true;
                break;
            case "Pendulo":
                jugadorCortado = true;
                movimientoSpt.sinMovimiento = true; //<- Spt de movimiento
                //movimientoSpt.enabled = false;
                break;
            default:
                break;
        }
    }
}
