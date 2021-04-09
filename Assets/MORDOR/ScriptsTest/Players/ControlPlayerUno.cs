using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerUno : Player
{
    public int puntajePlayerUno;

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
        }
        if (aplastado)
        {
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
    }



    public override void DireccionMovimiento()
    {
        if(!moverseAtras && !moverseAdelante && !sinMovimiento)
        {
            if (Input.GetKey("w") && !caminoBloqueado)
            {
                posicionPlataforma = transform.position + distanciaPlataforma;
                moverseAdelante = true;
            }
            else if (Input.GetKey("s"))
            {
                posicionPlataforma = transform.position - distanciaPlataforma;
                moverseAtras = true;
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
}


