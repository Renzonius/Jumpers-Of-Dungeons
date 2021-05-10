using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerDos : Player
{
    public int puntajePlayerDos;

    public Animator animator_backu;


    private void FixedUpdate()
    {
        if (enSuelo)
        {
            DireccionMovimiento();
            DesactivarTrampas();
            ControlesDeInteraccion();
        }

        if (activarSpawn)
        {
            VolverASpawnear();
            animator_backu.SetBool("danno_backu", false);
        }

        if (jugadorCortado)
        {
            cortePendulo();
            animator_backu.SetBool("danno_backu", true);
        }


        if (aplastado)
        {
            Aplastamiento();
            Estirar();
        }


        if (moverseAdelante)
        {
            MovimientoAdelante();
        }
        else if (moverseAtras)
        {
            MovimientoAtras();
        }

        if(corriendo)
        {
            rigiRef.useGravity = false;
            MovimientoCorrer();
            animator_backu.SetBool("correr_backu", true);
        }
        else
            animator_backu.SetBool("correr_backu", false);

        if (sigiloso)
        {
            rigiRef.useGravity = false;
            MovimientoSigiloso();
            animator_backu.SetBool("sigilo_backu", true);
        }
        else
        {
            animator_backu.SetBool("sigilo_backu", false);
        }

    }

    public override void DireccionMovimiento()
    {
        if (!moverseAtras && !moverseAdelante && !sinMovimiento)
        {
            if (Input.GetKey("i") && !caminoBloqueado)
            {
                posicionPlataforma = transform.position + distanciaPlataforma;
                moverseAdelante = true;
                animator_backu.SetBool("dash_backu", true);
            }
            else if (Input.GetKey("k"))
            {
                posicionPlataforma = transform.position - distanciaPlataforma;
                moverseAtras = true;
                animator_backu.SetBool("dash_backu", true);
            }
        }
    }
    public override void DesactivarTrampas()
    {
        if (Input.GetKey("u"))
            usarDesactivador = true;
        else
            usarDesactivador = false;
    }

    public override void ControlesDeInteraccion()
    {
        if (cercaBarril)
        {
            if (Input.GetKey("o") && !llevaPolvora)
                llevaPolvora = true;
        }
        else if (cercaCañon)
        {
            if (Input.GetKey("o") && llevaPolvora)
            {
                llevaPolvora = false;
                CargarCañon();
            }
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
            puntoSpawn = col.gameObject.transform.position;
            animator_backu.SetBool("dash_backu", false);
        }
    }
}
