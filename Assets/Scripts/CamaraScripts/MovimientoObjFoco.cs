using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObjFoco : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Vector3 posPlayer1; 
    public Vector3 posPlayer2;
    public Vector3 posFoco;
    public float velocidadSmooth;

    bool enfocarBolaFuego = true;
    public GameObject bolaFuegoRef;
    public float tiempoIntro;

    float distanciaJugadores;
    bool introDesactivada;
    bool activarMovimientos;

    void Start()
    {
        posPlayer1 = player1.transform.position;
        posPlayer2 = player2.transform.position;
        posFoco = transform.position;

        bolaFuegoRef = GameObject.FindGameObjectWithTag("BolaFuego");
    }

    void FixedUpdate()
    {
        Intro();
        IrhastaJugadores();
        EnfocarJugadores();
    }
    void Intro()
    {
        if (enfocarBolaFuego)
        {
            if(tiempoIntro > 0)
            {
                posFoco = Vector3.Lerp(transform.position, bolaFuegoRef.transform.position, velocidadSmooth * Time.deltaTime);
                transform.position = posFoco;
                tiempoIntro -= Time.deltaTime;
                //Debug.Log("Foco siguiendo a la bola de fuego");
            }
            else
            {
                enfocarBolaFuego = false;
            }
        }
    }

    void EnfocarJugadores()
    {
        if (introDesactivada && !activarMovimientos)
        {
            posFoco.z = player1.transform.position.z / 2 + player2.transform.position.z / 2;
            posFoco.x = player1.transform.position.x / 2 + player2.transform.position.x / 2;
            posFoco = Vector3.Lerp(transform.position, posFoco, velocidadSmooth * Time.deltaTime);
            transform.position = posFoco;
            //Debug.Log("Foco siguiendo a los personajes");
        }
    }

    void IrhastaJugadores()
    {
        if (!enfocarBolaFuego)
        {
            distanciaJugadores = Vector3.Distance(transform.position, player1.transform.position);
            if (distanciaJugadores < 0 && !introDesactivada)
            {
                velocidadSmooth = 1f;
            }
            else
            {
                //Debug.Log("Termino Intro");
                introDesactivada = true;
                activarMovimientos = true;
                velocidadSmooth = 1f;
            }

            if (introDesactivada && activarMovimientos)
            {
                player1.GetComponent<MovimientoGeneral>().enabled = true;
                player2.GetComponent<MovimientoGeneral>().enabled = true;
                activarMovimientos = false;
                //Debug.Log("Movimientos Activados");

            }
        }
    }
}
