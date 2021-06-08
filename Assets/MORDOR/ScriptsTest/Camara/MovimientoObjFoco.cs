using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObjFoco : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Vector3 posPlayer1; 
    public Vector3 posPlayer2;
    public Vector3 posFoco;
    public float velocidadSmooth;

    void Start()
    {
        posPlayer1 = player1.transform.position;
        posPlayer2 = player2.transform.position;
        posFoco = transform.position;
    }

    void FixedUpdate()
    {
        posFoco.z = player1.transform.position.z/2 + player2.transform.position.z/2;
        posFoco.x = player1.transform.position.x / 2 + player2.transform.position.x / 2;
        posFoco = Vector3.Lerp(transform.position, posFoco, velocidadSmooth * Time.deltaTime) ;
        transform.position = posFoco ;
    }
}
