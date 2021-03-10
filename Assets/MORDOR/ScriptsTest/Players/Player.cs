﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    [Header ("MOVIMIENTO")]
    #region Movimiento
    [SerializeField] bool _moverseAdelante;
    public bool moverseAdelante { get { return _moverseAdelante; } set { _moverseAdelante = value; } }

    [SerializeField] bool _moverseAtras;
    public bool moverseAtras { get { return _moverseAtras; } set { _moverseAtras = value; } }

    [SerializeField] bool _moverseDerecha;
    public bool moverseDerecha { get { return _moverseDerecha; } set { _moverseDerecha = value; } }

    [SerializeField] bool _moverseIzquierda;
    public bool moverseIzquierda { get { return _moverseIzquierda; } set { _moverseIzquierda = value; } }

    [SerializeField] bool _enSuelo;
    public bool enSuelo { get { return _enSuelo; } set { _enSuelo = value; } }

    [SerializeField] bool _sinMovimiento;
    public bool sinMovimiento { get { return _sinMovimiento; } set { _sinMovimiento = value; } }

    [SerializeField] bool _usarDesactivador;
    public bool usarDesactivador { get { return _usarDesactivador; } set { _usarDesactivador = value; } }

    [SerializeField] float _velocidadMovimiento;
    public float velocidadMovimiento { get { return _velocidadMovimiento; } set { _velocidadMovimiento = value; } }

    [SerializeField] float _tiempoEntreSaltos;
    public float tiempoEntreSaltos { get { return _tiempoEntreSaltos; } set { _tiempoEntreSaltos = value; } }

    public Vector3 distanciaPlataforma;
    public Vector3 posicionPlataforma;
    #endregion

    [Header ("SPAWN")]
    #region SPAWN
    [SerializeField] public bool _activarSpawn;
    public bool activarSpawn { get { return _activarSpawn; } set { _activarSpawn = value; } }
    [SerializeField] public float _tiempoSpawn;
    public float tiempoSpawn { get { return _tiempoSpawn; } set { _tiempoSpawn = value; } }
    [SerializeField] public Vector3 _puntoSpawn;
    public Vector3 puntoSpawn { get { return _puntoSpawn; } set { _puntoSpawn = value; } }

    public GameObject cuerpo;
    #endregion

    [Header("PUNTAJE")]
    public GameObject inventario;
    public int puntaje;

    void Start()
    {
        velocidadMovimiento = 20f;
        tiempoEntreSaltos = 0.5f;
        distanciaPlataforma = new Vector3(0, 0, 5f);
        tiempoSpawn = 3f;
    }

    private void FixedUpdate()
    {
        if (enSuelo)
        {
            DireccionMovimiento();
            DesactivarTrampas();
        }

        if(activarSpawn)
        {
            VolverASpawnear();
        }

        if (moverseAdelante)
        {
            MovimientoAdelante();

        }
        else if (moverseAtras)
        {
            MovimientoAtras();
        }
    }

    public abstract void DireccionMovimiento();
    public abstract void DesactivarTrampas();

    public void VolverASpawnear()
    {
        tiempoSpawn -= Time.deltaTime;
        if( tiempoSpawn <= 0)
        {
            transform.position = new Vector3(-2f, 0, 0);
            cuerpo.SetActive(true);
            tiempoSpawn = 3f;
            activarSpawn = false;
            transform.position = puntoSpawn;
        }

    }

    public void MovimientoAdelante()
    {
        transform.position = Vector3.MoveTowards(transform.position, posicionPlataforma, velocidadMovimiento * Time.deltaTime);
        tiempoEntreSaltos -= Time.deltaTime;

        if (transform.position == posicionPlataforma && tiempoEntreSaltos <= 0)
        {
            tiempoEntreSaltos = 0.5f;
            moverseAdelante = false;
        }
    }

    public void MovimientoAtras()
    {
        transform.position = Vector3.MoveTowards(transform.position, posicionPlataforma, velocidadMovimiento * Time.deltaTime);
        tiempoEntreSaltos -= Time.deltaTime;

        if (transform.position == posicionPlataforma && tiempoEntreSaltos <= 0)
        {
            tiempoEntreSaltos = 0.5f;
            moverseAtras = false;
        }
    }

    public void MovimientoDerecha()
    {
        transform.position = Vector3.MoveTowards(transform.position, posicionPlataforma, velocidadMovimiento * Time.deltaTime);
        tiempoEntreSaltos -= Time.deltaTime;

        if (transform.position == posicionPlataforma && tiempoEntreSaltos <= 0)
        {
            tiempoEntreSaltos = 0.5f;
            moverseDerecha = false;
            //posicionPlataforma.z += distanciaSalto;
        }
    }

    public void MovimientoIzquierda()
    {
        transform.position = Vector3.MoveTowards(transform.position, distanciaPlataforma, velocidadMovimiento * Time.deltaTime);
        tiempoEntreSaltos -= Time.deltaTime;

        if (transform.position == distanciaPlataforma && tiempoEntreSaltos <= 0)
        {
            tiempoEntreSaltos = 0.5f;
            moverseIzquierda = false;
            //distanciaPlataforma.z -= distanciaSalto;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
            puntoSpawn = col.gameObject.transform.position;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Oscuridad"))
        {
            activarSpawn = true;
            cuerpo.SetActive(false);
        }
    }
}
