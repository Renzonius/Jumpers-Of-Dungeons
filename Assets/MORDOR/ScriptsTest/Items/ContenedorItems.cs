using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContenedorItems : MonoBehaviour
{
    public GameObject[] conjuntoItems;
    public float tiempoRecoleccion;
    public float velocidadMovimientoItem;
    public ControlPlayerUno sptPlayer1;
    public GameObject playerRef;
    public ControlPlayerDos sptPlayer2;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //JugadorTomaItems();
        Movimiento();
    }

    private void OnTriggerEnter(Collider col)
    {
        string tipoTag = col.gameObject.tag;
        switch (tipoTag)
        {
            case "Player":
                playerRef = col.gameObject;
                sptPlayer1 = playerRef.GetComponent<ControlPlayerUno>();
                foreach (GameObject item in conjuntoItems)
                {
                    item.GetComponent<Doblon>().playerObjetivoRef = playerRef; 
                }
                break;
            case "Player2":
                playerRef = col.gameObject;
                foreach (GameObject item in conjuntoItems)
                {
                    item.GetComponent<Doblon>().playerObjetivoRef = playerRef;
                }
                break;
            default:
                break;
        }
    }


    //public void JugadorTomaItems() SISTEMA PARA AGARRAR ITEMS
    //{
    //    if (sptPlayer1 != null)
    //    {
    //        if (sptPlayer1.tomandoItems && tiempoRecoleccion >= 0)
    //        {
    //            tiempoRecoleccion -= 0.5f;

    //            switch (tiempoRecoleccion)
    //            {
    //                case 80:
    //                    conjuntoItems[0].GetComponent<Doblon>().tomarItem = true;
    //                    break;
    //                case 60:
    //                    conjuntoItems[1].GetComponent<Doblon>().tomarItem = true;
    //                    break;
    //                case 40:
    //                    conjuntoItems[2].GetComponent<Doblon>().tomarItem = true;
    //                    break;
    //                case 20:
    //                    conjuntoItems[3].GetComponent<Doblon>().tomarItem = true;
    //                    break;
    //                case 0:
    //                    conjuntoItems[4].GetComponent<Doblon>().tomarItem = true;
    //                    break;
    //                default:
    //                    break;
    //            }

    //        }
    //    }

    //}

    public void Movimiento()
    {
        gameObject.transform.Rotate(0, 1.5f - Time.deltaTime, 0);
    }

}
