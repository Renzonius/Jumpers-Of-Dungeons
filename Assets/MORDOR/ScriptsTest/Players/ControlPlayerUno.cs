using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerUno : Player
{
    public int puntajePlayerUno;
    public Animator animator_tuxxi;

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
            animator_tuxxi.SetBool("pendulo_tuxxi", false);
        }
        
        if (aplastado)
        {
            Aplastamiento();
            Estirar();
        }

        if (jugadorCortado)
        {
            cortePendulo();
            animator_tuxxi.SetBool("pendulo_tuxxi", true);
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
            animator_tuxxi.SetBool("correr_tuxxi", true);
        }
        else
            animator_tuxxi.SetBool("correr_tuxxi", false);

        if (sigiloso)
        {
            rigiRef.useGravity = false;
            MovimientoSigiloso();
            animator_tuxxi.SetBool("sigilo_tuxxi", true);
        }
        else
            animator_tuxxi.SetBool("sigilo_tuxxi", false);
        

    }

    public override void DireccionMovimiento()
    {
        if(!moverseAtras && !moverseAdelante && !sinMovimiento)
        {
            if (Input.GetKey("w") && !caminoBloqueado)
            {
                posicionPlataforma = transform.position + distanciaPlataforma;
                moverseAdelante = true;
                animator_tuxxi.SetBool("dash_tuxxi", true);
            }
            else if (Input.GetKey("s"))
            {
                posicionPlataforma = transform.position - distanciaPlataforma;
                moverseAtras = true;
                animator_tuxxi.SetBool("dash_tuxxi", true);
            }
        }
    }

    public override void DesactivarTrampas()
    {
        if (Input.GetKey("e"))
            usarDesactivador = true;
        else
            usarDesactivador = false;
    }

    public override void ControlesDeInteraccion()
    {
        if (cercaBarril)
        {
            if (Input.GetKey("q") && !llevaPolvora)
                llevaPolvora = true;
        }
        else if (cercaCañon)
        {
            if (Input.GetKey("q") && llevaPolvora)
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
            animator_tuxxi.SetBool("dash_tuxxi", false);
        }
    }
}


