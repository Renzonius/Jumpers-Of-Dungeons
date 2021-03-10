using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroFuego : MonoBehaviour
{
    public float velocidad;
    public Vector3 posicion;
    void Start()
    {
        posicion = transform.position;
    }

    void FixedUpdate()
    {
        posicion.z += velocidad * Time.deltaTime;
        transform.position = posicion;
    }
}
