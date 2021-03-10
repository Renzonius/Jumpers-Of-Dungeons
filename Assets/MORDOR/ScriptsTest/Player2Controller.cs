using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    Vector3 posicionPlataforma;
    public GameObject objetivo;
    public bool moverseAdelante;
    public bool moverseAtras;
    public bool moverseIzq;
    public bool moverseDer;
    public float velocidad = 20f;
    float distanciaSalto = 3f;
    public float esperarSalto = 0.5f;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (!moverseAtras && Input.GetKey("up") && !moverseAdelante)
        {
            posicionPlataforma = transform.position + new Vector3(0, 0, 5f);
            moverseAdelante = true;
        }
        else if (!moverseAdelante && Input.GetKey("down") && !moverseAtras)
        {
            posicionPlataforma = transform.position + new Vector3(0, 0, -5f);
            moverseAtras = true;
        }

        if (moverseAdelante)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionPlataforma, velocidad * Time.deltaTime);
            esperarSalto -= Time.deltaTime;

            if (transform.position == posicionPlataforma && esperarSalto <= 0)
            {
                esperarSalto = 0.5f;
                moverseAdelante = false;
                posicionPlataforma.z += distanciaSalto;
            }
        }
        else if (moverseAtras)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionPlataforma, velocidad * Time.deltaTime);
            esperarSalto -= Time.deltaTime;

            if (transform.position == posicionPlataforma && esperarSalto <= 0)
            {
                esperarSalto = 0.5f;
                moverseAtras = false;
                posicionPlataforma.z -= distanciaSalto;
            }
        }
    }
}
