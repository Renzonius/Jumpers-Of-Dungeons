using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrensaInteraccion : MonoBehaviour
{
    public bool aplastado;
    public float tiempoAplastado;

    Vector3 escala;
    Vector3 escalaPredeterminada;

    public GameObject particulasDoblenes;

    void Aplastamiento()
    {
        escala = transform.localScale;
        escala.y = 0.5f;
        transform.localScale = escala;
    }

    void EscalaPredeterminada()
    {
        tiempoAplastado -= Time.deltaTime;
        if (tiempoAplastado <= 0f)
        {
            transform.localScale = escalaPredeterminada;
            aplastado = false;
            tiempoAplastado = 3f;
            //Setear sinMovimiento -> false (por ahora lo seteamos en movimiento general)
        }
    }

    void Start()
    {
        tiempoAplastado = 3f;
        escalaPredeterminada = transform.localScale;
    }

    void FixedUpdate()
    {
        if(aplastado)
            EscalaPredeterminada();
    }

    private void OnTriggerEnter(Collider col)
    {
        string tipoTag = col.gameObject.tag;
        if (tipoTag == "Prensadora")
        {
            Instantiate(particulasDoblenes, transform.position, particulasDoblenes.transform.rotation);
            aplastado = true;
            Aplastamiento();
        }
    }
}
