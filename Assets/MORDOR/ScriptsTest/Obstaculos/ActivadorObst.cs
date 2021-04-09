using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorObst : MonoBehaviour
{
    public Obstaculo sptObstaculo;
    public ControlPlayerUno sptPlayer;
    public ControlPlayerDos sptPlayerDos;

    [SerializeField] private float _tiempoActivo;
    public float tiempoActivo { get { return _tiempoActivo; } set { _tiempoActivo = value; } }

    [SerializeField] private bool _activado;
    public bool activado { get { return _activado; } set { _activado = value; } }

    private void Start()
    {
        tiempoActivo = 0.5f;
        sptPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlPlayerUno>();
        sptPlayerDos = GameObject.FindGameObjectWithTag("Player2").GetComponent<ControlPlayerDos>();
    }

    private void FixedUpdate()
    {
        if (activado)
        {
            tiempoActivo -= Time.deltaTime;
        }

        if (tiempoActivo <= 0)
        {
            activado = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            sptObstaculo.obstActivado = true;
            sptPlayer.sinMovimiento = true;
            activado = true;

        }
        else if (col.gameObject.CompareTag("Player2"))
        {
            sptObstaculo.obstActivado = true;
            sptPlayerDos.sinMovimiento = true;
            activado = true;

        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            sptObstaculo.obstActivado = false;
        }
    }
}
