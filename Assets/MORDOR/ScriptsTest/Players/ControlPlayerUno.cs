using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerUno : Player
{
    public override void DireccionMovimiento()
    {
        if(!moverseAtras && !moverseAdelante && !sinMovimiento)
        {
            if (Input.GetKey("w"))
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
}
