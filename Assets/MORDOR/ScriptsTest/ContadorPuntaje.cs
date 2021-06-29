using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorPuntaje : MonoBehaviour
{

    public Puntaje puntajePlayerUno;
    public Puntaje puntajePlayerDos;

    Text marcadorPuntaje;
    public int puntajeTotal;
    float puntos = 0f;
    void Start()
    {
        puntajePlayerUno = GameObject.FindGameObjectWithTag("Player").GetComponent<Puntaje>();
        puntajePlayerDos = GameObject.FindGameObjectWithTag("Player2").GetComponent<Puntaje>();
        puntajeTotal = puntajePlayerUno.puntaje + puntajePlayerDos.puntaje;
        
        
        marcadorPuntaje = GetComponent<Text>();
        marcadorPuntaje.text = " " + puntos;
    }


    IEnumerator EfectoAcumulacion()
    {
        yield return new WaitForSeconds(1.5f);
        if (puntos < puntajeTotal)
        {
            puntos++;
            marcadorPuntaje.text = " " + puntos;
        }
    }


    void Update()
    {
        StartCoroutine(EfectoAcumulacion());
    }
}
