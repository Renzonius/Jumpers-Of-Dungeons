using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prensadora : MonoBehaviour
{
    public Vector3 posPrensa;
    public bool desactivada;
    public bool aplastoPlayer;
    public Vector3 posInicial;
    public Vector3 posFinal;
    public float velMovimientoBajada;
    public float velMovimientoSubida;
    public float tiempoEspera;
    public ControlPlayerUno sptPlayerUno;
    public ControlPlayerDos sptPlayerDos;
    public bool aplastoJugador;

    public bool realizarReccorrido;

    void Start()
    {
        sptPlayerUno = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlPlayerUno>();
        sptPlayerDos = GameObject.FindGameObjectWithTag("Player2").GetComponent<ControlPlayerDos>();
        posPrensa = transform.localPosition;
    }

    void FixedUpdate()
    {
        Movimiento();
    }

    public void Movimiento()
    {
        if (!desactivada)
        {
            if (!realizarReccorrido)
            {
                BajaPrensa();
            }
            else
            {
                SubePrensa();
            }
        }
    }


    public void BajaPrensa()
    {
        if (transform.localPosition == posFinal)
        {
            tiempoEspera -= Time.deltaTime;
            if (tiempoEspera <= 0)
            {
                realizarReccorrido = true;
                tiempoEspera = 2f;
            }

        }
        else
        {
            posPrensa = Vector3.MoveTowards(posPrensa, posFinal, velMovimientoBajada * Time.deltaTime);
            transform.localPosition = posPrensa;
        }
    }

    public void SubePrensa()
    {
        if(transform.localPosition == posInicial)
        {
            if (aplastoJugador)
            {
                desactivada = true;
            }
            else
            {
                tiempoEspera -= Time.deltaTime;
                if (tiempoEspera <= 0)
                {
                    realizarReccorrido = false;
                    tiempoEspera = 1f;
                }
            }
        }
        else
        {
            posPrensa = Vector3.MoveTowards(posPrensa, posInicial, velMovimientoSubida * Time.deltaTime);
            transform.localPosition = posPrensa;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player2"))
        {
            aplastoJugador = true;
        }
    }
}
