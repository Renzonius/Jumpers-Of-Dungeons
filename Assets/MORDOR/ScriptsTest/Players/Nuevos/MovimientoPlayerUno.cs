using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayerUno : MonoBehaviour, IMovimiento
{
    bool enSuelo;
    bool sinMovimiento;
    bool caminoBloqueado;

    bool moverseAdelante;
    bool moverseAtras;

    float volociadadMovimiento;
    float tiempoEntreSaltos;

    Quaternion mirarAdelante;
    Quaternion mirarAtras;

    public void MovimientoAdelante() 
    { 

    }
    public void MovimientoAtras() 
    { 

    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        string tipoTag = col.gameObject.tag;
        switch (tipoTag)
        {
            case "GranPorton":
                caminoBloqueado = true;
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        string tipoTag = col.gameObject.tag;
        switch (tipoTag)
        {
            case "GranPorton":
                caminoBloqueado = false;
                break;
            default:
                break;
        }
    }
}
