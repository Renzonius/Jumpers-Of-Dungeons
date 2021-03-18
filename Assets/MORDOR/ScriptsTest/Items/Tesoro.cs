using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tesoro : MonoBehaviour
{
    //public GameObject itemRef;
    public int puntajeItem;
    public ControlPlayerUno sptPlayer1;
    public ControlPlayerDos sptPlayer2;
    public float velMovimiento;
    public bool movimientoLocal;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Movimiento();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            sptPlayer1.puntaje += puntajeItem;
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("Player2"))
        {
            sptPlayer2.puntaje += puntajeItem;
            Destroy(gameObject);
        }
    }

    public abstract void Movimiento();
}
