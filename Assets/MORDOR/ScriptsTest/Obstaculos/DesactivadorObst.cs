using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivadorObst : MonoBehaviour
{
    public Obstaculo scriptObstaculo;
    public ControlPlayerUno sptPlayer;
    public ControlPlayerDos sptPlayerDos;
    public ActivadorObst sptActivador;
    [SerializeField] private bool _desactivado;
    public bool desactivado { get { return _desactivado; } set { _desactivado = value; } }



    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if (sptActivador.activado == false && sptPlayer.usarDesactivador == true)
            {
                scriptObstaculo.obstActivado = false;
                sptPlayerDos.sinMovimiento = false;
            }
        }
        if (col.gameObject.CompareTag("Player2"))
        {
            if (sptActivador.activado == false && sptPlayerDos.usarDesactivador == true)
            {
                scriptObstaculo.obstActivado = false;
                sptPlayer.sinMovimiento = false;
            }
        }
    }
}
