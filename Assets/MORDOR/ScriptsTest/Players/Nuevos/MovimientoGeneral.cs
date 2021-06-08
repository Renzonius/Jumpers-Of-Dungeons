using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoGeneral : MonoBehaviour, IMovimiento
{
    public bool enSuelo;
    [SerializeField] bool _sinMovimiento;
    public bool sinMovimiento { get { return _sinMovimiento; } set { _sinMovimiento = value; } }
    bool _caminoBloqueado;
    public bool caminoBloqueado { get { return _caminoBloqueado; } set { _caminoBloqueado = value; } }


    public string teclaMovimientoAdelante;
    public string teclaMovimientoAtras;

    bool moverseAdelante;
    bool moverseAtras;

    public float velocidadMovimiento;
    public float tiempoEntreSaltos;

    Quaternion mirarAdelante;
    Quaternion mirarAtras;

    public Vector3 distanciaPlataforma;
    public Vector3 posicionPlataforma;

    //Animator animator_tuxxi;
    public void MovimientoAdelante()
    {
        transform.position = Vector3.MoveTowards(transform.position, posicionPlataforma, velocidadMovimiento * Time.deltaTime);
        tiempoEntreSaltos -= Time.deltaTime;

        if (transform.position == posicionPlataforma && tiempoEntreSaltos <= 0)
        {
            tiempoEntreSaltos = 0.5f;
            moverseAdelante = false;
        }
        if (transform.rotation == mirarAtras)
        {
            transform.Rotate(0, 180, 0);
            mirarAdelante = transform.rotation;
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
        if (transform.rotation == mirarAdelante)
        {
            transform.Rotate(0, 180, 0);
            mirarAtras = transform.rotation;
        }
    }
    public void DireccionMovimiento()
    {
        if (!moverseAtras && !moverseAdelante && !sinMovimiento)
        {
            if (Input.GetKey(teclaMovimientoAdelante) && !caminoBloqueado)
            {
                posicionPlataforma = transform.position + distanciaPlataforma;
                moverseAdelante = true;
                //animator_tuxxi.SetBool("dash_tuxxi", true);
            }
            else if (Input.GetKey(teclaMovimientoAtras))
            {
                posicionPlataforma = transform.position - distanciaPlataforma;
                moverseAtras = true;
                //animator_tuxxi.SetBool("dash_tuxxi", true);
            }
        }
    }

    void Start()
    {
        mirarAdelante = transform.rotation;
    }

    void FixedUpdate()
    {
        if (enSuelo)
        {
            DireccionMovimiento();
        }

        if (moverseAdelante && !moverseAtras)
        {
            MovimientoAdelante();
        }
        else if (moverseAtras && !moverseAdelante)
        {
            MovimientoAtras();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        string tipoTag = col.gameObject.tag;
        switch (tipoTag)
        {
            case "JaulaTrampa":
                sinMovimiento = true;
                break;
            case "Prensadora":
                sinMovimiento = true;
                break;
            case "GranPorton":
                caminoBloqueado = true;
                break;
            default:
                break;
        }
    }
    private void OnTriggerStay(Collider col)
    {
        string tipoTag = col.gameObject.tag;
        Activador activadorJaula;
        switch (tipoTag)
        {
            case "JaulaTrampa":
                activadorJaula = col.gameObject.GetComponent<Activador>();
                if (activadorJaula.activado)
                {
                    sinMovimiento = true;
                }
                else
                {
                    sinMovimiento = false;
                }
                break;
            default:
                break;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        string tipoTag = col.gameObject.tag;
        switch (tipoTag)
        {
            case "Prensadora":
                sinMovimiento = false;
                break;
            case "GranPorton":
                caminoBloqueado = false;
                break;
            default:
                break;
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Suelo") || col.gameObject.CompareTag("SueloTrampa"))
        {
            enSuelo = true;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        string tipoTag = col.gameObject.tag;
        switch (tipoTag)
        {
            case "Suelo":
                enSuelo = false;
                break;
            default:
                break;
        }
    }
}
