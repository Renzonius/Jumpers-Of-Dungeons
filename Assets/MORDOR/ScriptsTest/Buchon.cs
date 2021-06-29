using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buchon : MonoBehaviour
{
    GameObject jugadorUnoRef;
    GameObject jugadorDosRef;

    public GameObject bolaFuegoRef;

    void Start()
    {
        jugadorUnoRef = GameObject.FindGameObjectWithTag("Player");
        jugadorDosRef = GameObject.FindGameObjectWithTag("Player2");
        bolaFuegoRef = GameObject.FindGameObjectWithTag("BolaFuego");
    }

    void Update()
    {
        EstadoPerder();
        EstadoGanar();
    }

    void EstadoPerder()
    {
       if(jugadorDosRef.GetComponent<Perder>().perder || jugadorUnoRef.GetComponent<Perder>().perder)
       {
            jugadorDosRef.GetComponent<MovimientoGeneral>().sinMovimiento = true;
            jugadorUnoRef.GetComponent<MovimientoGeneral>().sinMovimiento = true;
       }
    }

    void EstadoGanar()
    {
        if(jugadorDosRef.GetComponent<Ganar>().salidaJugador && jugadorUnoRef.GetComponent<Ganar>().salidaJugador)
        {
            bolaFuegoRef.GetComponent<MuroFuego>().enabled = false;
            if(bolaFuegoRef.transform.localScale.x > 0)
                bolaFuegoRef.transform.localScale -= new Vector3(1.5f, 1.5f, 1.5f) * Time.deltaTime;
            bolaFuegoRef.GetComponent<SphereCollider>().enabled = false;
        }
    }
}
