using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerDos : Player
{
    public override void DireccionMovimiento()
    {
        if (!moverseAtras && !moverseAdelante && !sinMovimiento)
        {
            if (Input.GetKey("i"))
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
}
