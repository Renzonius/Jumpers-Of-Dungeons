using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tesoro : MonoBehaviour
{
    //public GameObject itemRef;
    public int puntajeItem;
    public ControlPlayerUno sptPlayerUno;
    public GameObject playerUnoRef;
    public ControlPlayerDos sptPlayerDos;
    public GameObject playerDosRef;
    public float velMovimiento;
    public bool movimientoLocal;



    void FixedUpdate()
    {
        Movimiento();
    }

    private void OnTriggerEnter(Collider col)
    {
        string tipoTag = col.gameObject.tag;
        switch (tipoTag)
        {
            case "Player":
                sptPlayerUno.puntaje += puntajeItem;
                Destroy(gameObject);
                break;
            case "Player2":
                sptPlayerDos.puntaje += puntajeItem;
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

    public abstract void Movimiento();

    public Vector3 AtraerItem(Transform tranformItem, GameObject player)
    {
        Vector3 posicionItem;
        Vector3 posicionPlayer;
        posicionItem = tranformItem.position;
        posicionPlayer = player.transform.position;
        posicionItem = Vector3.MoveTowards(posicionItem, posicionPlayer, 20f * Time.deltaTime);
        return posicionItem;
    }
}
