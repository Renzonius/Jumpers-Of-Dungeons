﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raton : MonoBehaviour
{
    public float velMovimiento;
    public float tiempoEspera;
    public float valorTiempo;
    public GameObject posBRef;
    public GameObject posARef;
    public GameObject ratonRef;
    public Vector3 posB;
    public Vector3 posA;
    public Vector3 posActual;
    public Vector3[] posiciones;
    public int valorMaxPos;
    public bool enPosicion;
    int valor;
    

    void Start()
    {
        valor = 0;
        tiempoEspera = 3f;
        posB = posBRef.transform.localPosition;
        posA = posARef.transform.localPosition;
        posActual = ratonRef.transform.localPosition;
    }

    void FixedUpdate()
    {
        Movimiento();   
    }

    public void Movimiento()
    {
        if (!enPosicion)
        {
            posActual = Vector3.MoveTowards(posActual, posiciones[valor], velMovimiento * Time.deltaTime);
            ratonRef.transform.localPosition = posActual;

            if (posActual == posiciones[0] || posActual == posiciones[1] || posActual == posiciones[2])
            {
                enPosicion = true;
                if (posActual == posiciones[2])
                {
                    tiempoEspera = 5;
                }
            }
        }
        else
        {
            tiempoEspera -= Time.deltaTime;
            if (tiempoEspera <= 0f)
            {
                tiempoEspera = valorTiempo;
                enPosicion = false;
                if (valor >= valorMaxPos)
                {
                    valor = 0;
                    ratonRef.transform.LookAt(posARef.transform);
                }
                else
                {
                    valor++;
                    ratonRef.transform.LookAt(posBRef.transform);
                }
            }
        }
    }
}