using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDPuntaje : MonoBehaviour
{
    public Puntaje player1;
    public Puntaje player2;

    //public int puntajeTotal;
    public int puntajeTotalAnterior;
    public Text marcador;


    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Puntaje>();
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Puntaje>();
        marcador = GetComponent<Text>();
    }

    void SumarPuntaje()
    {
        //int puntajeTotal = player1.puntaje + player2.puntaje;
        //puntajeTotalAnterior = puntajeTotal;
        //if(puntajeTotal != puntajeTotalAnterior)
        //{
        //    marcador.text = (puntajeTotal).ToString();
        //}
        marcador.text = (player1.puntaje + player2.puntaje).ToString();

    }

    void FixedUpdate()
    {
        SumarPuntaje();
    }
}
