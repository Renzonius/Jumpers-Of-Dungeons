using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioPlayerUno : MonoBehaviour, IPuntaje
{
    int puntaje;

    int valorDoblon = 3;

    public void SumarPuntaje(int puntos) 
    {
        puntaje += puntos;
    }
    public void RestarPuntaje()
    {
        if(puntaje > 1)
            puntaje -= puntaje/2;
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
            case "Oscuridad":
                RestarPuntaje();
                break;
            case "Prensadora":
                RestarPuntaje();
                break;
            case "Doblon":
                SumarPuntaje(valorDoblon);
                break;
            default:
                break;
        }
    }
}
