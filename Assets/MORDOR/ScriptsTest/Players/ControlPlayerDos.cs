using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerDos : Player
{
    public int puntajePlayerDos;
    

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
        if (!moverseAtras && !moverseAdelante && !sinMovimiento)
        {
            if (Input.GetKey("i") && !caminoBloqueado)
            {
                posicionPlataforma = transform.position + distanciaPlataforma;
                moverseAdelante = true;
            }
            else if (Input.GetKey("k"))
            {
                posicionPlataforma = transform.position - distanciaPlataforma;
                moverseAtras = true;
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
}
