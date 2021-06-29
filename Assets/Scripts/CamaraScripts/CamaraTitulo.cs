using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraTitulo : MonoBehaviour
{
    Vector3 posInicial;
    Vector3 posFinal = new Vector3(97.5f, 3f, 0);
    Vector3 pos;
    public bool moverse;
    public float velMovimiento;
    float tiempoEspera = 5f;
    void Start()
    {
        pos = transform.position;
        posInicial = transform.position;
    }

    void Update()
    {
        if(transform.position.x >= posInicial.x && !moverse)
        {
            pos = Vector3.MoveTowards(pos, posFinal, velMovimiento * Time.deltaTime);
            transform.position = pos;
            if(transform.position == posFinal)
            {
                if (tiempoEspera <= 0)
                {
                    moverse = true;
                    tiempoEspera = 5f;
                }
                else
                    tiempoEspera -= Time.deltaTime;
            }
        }
        else if(transform.position.x <= posFinal.x && moverse)
        {
            pos = Vector3.MoveTowards(pos, posInicial, velMovimiento * Time.deltaTime);
            transform.position = pos;
            if (transform.position == posInicial)
            {
                if (tiempoEspera <= 0)
                {
                    moverse = false;
                    tiempoEspera = 5f;
                }
                else
                    tiempoEspera -= Time.deltaTime;
            }
        }
    }
}
