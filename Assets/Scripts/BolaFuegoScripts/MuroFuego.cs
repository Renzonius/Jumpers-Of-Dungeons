using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroFuego : MonoBehaviour
{
    public float velocidad;
    public Vector3 posicion;

    public GameObject objetivoRef;
    public Vector3 posicionObejetivo;
    public float distancia;
    void Start()
    {
        posicion = transform.position;
        objetivoRef = GameObject.FindGameObjectWithTag("Objetivo");
    }

    void FixedUpdate()
    {
        posicion.z += velocidad * Time.deltaTime;
        transform.position = posicion;
        VelocidadSegunObjetivo();
    }



    void VelocidadSegunObjetivo()
    {
        posicionObejetivo = objetivoRef.transform.position;
        distancia = Vector3.Distance(transform.position, posicionObejetivo);
        if(distancia >= 20f && velocidad <=13)
        {
            velocidad += 0.5f * Time.deltaTime; 
        }
        else if(distancia < 50f && distancia >=20f)
        {
            velocidad = 3;
        }
        else if (distancia < 20f)
        {
            velocidad = 2f;
        }
    }
}
