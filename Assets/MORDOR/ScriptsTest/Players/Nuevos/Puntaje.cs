using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntaje : MonoBehaviour, IPuntaje
{
    public int puntaje;
    int valorItem;


    public void SumarPuntaje(int puntos)
    {
        puntaje += puntos;
    }

    public void RestarPuntaje()
    {
        if(puntaje >0)
            puntaje -= puntaje *30 /100;
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
            case "Moneda":
                valorItem = col.gameObject.GetComponent<Moneda>().puntajeItem;
                SumarPuntaje(valorItem);
                break;
            default:
                break;
        }
    }
}
