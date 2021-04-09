using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public ControlPlayerUno sptPlayerUno;
    public GameObject playerUnoRef;
    public ControlPlayerDos sptPlayerDos;
    public GameObject playerDosRef;
    public int puntajeItem;
    public float velMovimiento;

    void Start()
    {
        puntajeItem = 3;
        velMovimiento = 5;
        playerUnoRef = GameObject.FindGameObjectWithTag("Player");
        sptPlayerUno = playerUnoRef.GetComponent<ControlPlayerUno>();
        playerDosRef = GameObject.FindGameObjectWithTag("Player2");
        sptPlayerDos = playerDosRef.GetComponent<ControlPlayerDos>();
    }

    void FixedUpdate()
    {
        Movimiento();
    }

    public void Movimiento()
    {
        transform.Rotate(0, velMovimiento - Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider col)
    {
        string tipoTag = col.gameObject.tag;
        switch (tipoTag)
        {
            case "Player":
                sptPlayerUno.SumarPuntaje(puntajeItem);
                Destroy(gameObject);
                break;
            case "Player2":
                sptPlayerDos.SumarPuntaje(puntajeItem);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

}
