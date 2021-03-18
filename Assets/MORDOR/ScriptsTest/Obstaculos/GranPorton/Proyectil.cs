using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velMovimiento;
    public Vector3 posicion;
    void Start()
    {
        posicion = transform.position;
    }

    void FixedUpdate()
    {
        posicion.z += velMovimiento * Time.deltaTime;
        transform.position = posicion;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("GranPorton"))
        {
            Debug.Log("Destruido");
            Destroy(gameObject);
        }
    }
}
