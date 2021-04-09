using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doblon : Tesoro
{
    public GameObject playerObjetivoRef;
    public bool tomarItem;

    private void Start()
    {
        playerUnoRef = GameObject.FindGameObjectWithTag("Player");
        sptPlayerUno = playerUnoRef.GetComponent<ControlPlayerUno>();
        playerDosRef = GameObject.FindGameObjectWithTag("Player2");
        sptPlayerDos = playerDosRef.GetComponent<ControlPlayerDos>();
    }

    public override void Movimiento()
    {
        //transform.RotateAround(transform.position, Vector3.down, velMovimiento * Time.deltaTime);

        transform.Rotate(0, -velMovimiento * Time.deltaTime, 0);
    }

    private void FixedUpdate()
    {
        if(playerObjetivoRef && tomarItem)
            transform.position = AtraerItem(transform, playerObjetivoRef);
        Movimiento();
    }

}
